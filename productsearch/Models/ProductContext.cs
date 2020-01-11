using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductSearch.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext():base("DbCon")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<ProductSearch.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<ProductSearch.Models.Stock> Stocks { get; set; }

        public System.Data.Entity.DbSet<ProductSearch.Models.SalesOrder> SalesOrders { get; set; }

        public System.Data.Entity.DbSet<ProductSearch.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<ProductSearch.Models.Notification> Notifications { get; set; }
    }
}