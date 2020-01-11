using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class SubCategory
    {
        [Key]
        [Display(Name ="Subcategory ID")]
        public int SubCategoryID { get; set; }
        [Required]
        [Display(Name ="Subcategory")]
        public string SubCategoryName { get; set; }
        
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}