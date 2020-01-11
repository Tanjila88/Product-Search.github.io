using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class StockPurchaseVM
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public decimal PurchaseQuantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalCost { get { return (PurchasePrice * PurchaseQuantity); } }
        public string PurchaseDate { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public decimal StockQuantity { get; set; }
    }
}