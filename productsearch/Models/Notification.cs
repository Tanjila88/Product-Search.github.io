using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string NotifyText { get; set; }
        public string NotifyDate { get; set; }
    }
}