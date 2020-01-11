using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class SalesOrder
    {
        [Key]
        public int SalesOrderID { get; set; }
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public decimal OrderQnty { get; set; }
        public string SalesDate { get; set; }
    }
}