using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductSearch.Models;

namespace ProductSearch.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategories()
        {
            var categoryList = db.Categories.AsEnumerable().Select(c => new { id = c.CategoryID, name = c.CategoryName });
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubCategories(int id)
        {
            var subCategories = db.SubCategories.Where(s => s.CategoryID == id).AsEnumerable().Select(s=> new { id=s.SubCategoryID, name=s.SubCategoryName});
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts(int id)
        {
            var products = db.Products.Where(s => s.SubCategoryID == id).AsEnumerable().Select(s => new { id = s.ProductID, name = s.ProductName });
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetPurchaseHistory(int id)
        {
            var purchaseHistory = db.Purchases.Where(s => s.ProductID == id).AsEnumerable().Select(s => new { puid = s.PurchaseID, pid = s.ProductID, name = s.Product.ProductName, price = s.PurchasePrice, qnty = s.PurchaseQuantity, supplier = s.Supplier.SupplierName, totalCost = s.TotalCost, purDate = s.PurchaseDate.ToString() });
            return Json(purchaseHistory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNotifications()
        {
            var notification = db.Notifications.AsEnumerable().Select(n => new { notiId = n.NotificationID, text = n.NotifyText });
            return Json(notification, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NotficationCount()
        {
            int count = db.Notifications.Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}