using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }
        [Display(Name = "Product Name")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Display(Name = "Quantity")]
        public decimal PurchaseQuantity { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal PurchasePrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get { return (PurchasePrice * PurchaseQuantity); } }
        [Display(Name = "Purchase Date")]
        public string PurchaseDate { get; set; }
        [Display(Name ="Supplier")]
        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}