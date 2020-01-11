using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public bool IsAvailable { get; set; }
    }
}