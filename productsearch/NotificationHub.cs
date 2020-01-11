using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

using ProductSearch.Models;

namespace ProductSearch
{
    public class NotificationHub : Hub
    {
        private ProductContext db = new ProductContext();
        public void Notify()
        {
            var stockQnty = db.Stocks.FirstOrDefault(s => s.StockQuantity <= 5);
            if (stockQnty != null)
            {
                Notification n = new Notification();
                n.NotifyText = db.Products.FirstOrDefault(p => p.ProductID == stockQnty.ProductID).ProductName + " Stock is " + stockQnty.StockQuantity.ToString();
                n.NotifyDate = DateTime.Now.Date.ToString();
                db.Notifications.Add(n);
                db.SaveChanges();
            }
        }
    }
}