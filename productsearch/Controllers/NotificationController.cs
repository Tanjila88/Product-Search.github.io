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
    public class NotificationController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Notification
        public ActionResult Index()
        {
            return View(db.Notifications.ToList());
        }
        // + " Stock is " + stockQnty.StockQuantity.ToString()
        [HttpPost]
        public JsonResult SaveNotification()
        {
            bool result = false;
            var stockQnty = db.Stocks.FirstOrDefault(s => s.StockQuantity <= 5);
            if (stockQnty != null)
            {
                string prname = db.Products.FirstOrDefault(p => p.ProductID == stockQnty.ProductID).ProductName;
                var check = db.Notifications.Where(s => s.NotifyText.Contains(prname)).FirstOrDefault(); 
                if (check != null)
                {
                    if(prname != check.NotifyText)
                    {
                        Notification n = new Notification();
                        n.NotifyText = prname;
                        n.NotifyDate = DateTime.Now.Date.ToString();
                        db.Notifications.Add(n);
                        db.SaveChanges();
                        result = true;
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
