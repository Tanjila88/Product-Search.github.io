using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductSearch.Models;

namespace ProductSearch.Controllers
{
    public class PurchaseController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Purchase
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Product);
            return View(purchases.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Purchase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockPurchaseVM purchase)
        {
            try
            {
                Purchase pur = new Purchase();
                pur.ProductID = purchase.ProductID;
                pur.PurchaseQuantity = purchase.PurchaseQuantity;
                pur.PurchasePrice = purchase.PurchasePrice;
                pur.PurchaseDate = DateTime.Now.Date.ToString();
                pur.SupplierID = purchase.SupplierID;
                db.Purchases.Add(pur);
                db.SaveChanges();
                
                //if product available in stock table
                var productCount = db.Stocks.FirstOrDefault(p => p.ProductID == purchase.ProductID);
                if(productCount != null)
                {
                    productCount.StockQuantity += purchase.PurchaseQuantity;
                    db.Entry(productCount).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Stock st = new Stock();
                    st.ProductID = purchase.ProductID;
                    st.StockQuantity = purchase.PurchaseQuantity;
                    db.Stocks.Add(st);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", purchase.SupplierID);
                return View(purchase);
            }
            
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", purchase.ProductID);
            return View(purchase);
        }

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,ProductID,PurchaseQuantity,PurchasePrice,PurchaseDate,SupplierName")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", purchase.ProductID);
            return View(purchase);
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
