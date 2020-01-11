using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Category
    {
        [Key]
        [Display(Name ="Category ID")]
        public int CategoryID { get; set; }
        [Display(Name ="Catagory Name")]
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}