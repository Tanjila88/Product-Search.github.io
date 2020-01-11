using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Measurment Unit")]
        public string Unit { get; set; }
        [Display(Name = "Subcategory")]
        public int SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}