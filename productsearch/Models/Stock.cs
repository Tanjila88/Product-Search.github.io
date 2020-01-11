using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public decimal StockQuantity { get; set; }
    }
}