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
    public class StockController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStockInfo()
        {
            var stockInfo = from s in db.Stocks
                            join p in db.Products
                            on s.ProductID equals p.ProductID
                            select new
                            {
                                id = s.StockID,
                                name = p.ProductName,
                                qnty = s.StockQuantity
                            };
            return Json(stockInfo, JsonRequestBehavior.AllowGet);
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
