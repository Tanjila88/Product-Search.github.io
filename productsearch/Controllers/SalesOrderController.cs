using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductSearch.Models;

namespace ProductSearch.Controllers
{
    public class SalesOrderController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: SalesOrder
        public ActionResult Index()
        {
            var salesOrders = db.SalesOrders.Include(s => s.Item);
            return View(salesOrders.ToList());
        }

        // GET: SalesOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        public JsonResult GetItems()
        {
            var items = from p in db.Products
                        join i in db.Items
                        on p.ProductID equals i.ProductID
                        where p.ProductID == i.ProductID
                        select new
                        {
                            id = i.ItemID,
                            name= p.ProductName
                        };
            
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        // GET: SalesOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesOrderID,ItemID,OrderQnty,SalesDate")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                salesOrder.SalesDate = DateTime.Now.Date.ToString();
                db.SalesOrders.Add(salesOrder);
                db.SaveChanges();

                //if product available in stock table
                int itemId = salesOrder.ItemID;
                var proid = (from st in db.Stocks
                             join pr in db.Products
                             on st.ProductID equals pr.ProductID
                             join it in db.Items
                             on pr.ProductID equals it.ProductID
                             where it.ItemID == itemId
                             select st).FirstOrDefault();
                
                if (proid != null)
                {
                    proid.StockQuantity -= salesOrder.OrderQnty;
                    db.Entry(proid).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemID", salesOrder.ItemID);
            return View(salesOrder);
        }

        // GET: SalesOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemID", salesOrder.ItemID);
            return View(salesOrder);
        }

        // POST: SalesOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesOrderID,ItemID,OrderQnty,SalesDate")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemID", salesOrder.ItemID);
            return View(salesOrder);
        }

        // GET: SalesOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(salesOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
