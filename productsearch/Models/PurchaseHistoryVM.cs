using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class PurchaseHistoryVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int PurchaseID { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseDate { get; set; }
        public string SupplierName { get; set; }
    }
}