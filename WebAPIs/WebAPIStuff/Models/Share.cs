using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIStuff.Models
{
    public class Share
    {
        [Key]
        public int ID { get; set; }
        public decimal price { get; set; }
        public int stockID { get; set; }
        public int customerID { get; set; }

        public virtual Stock stock { get; set; }
        public virtual Customer customer { get; set; }
    }
}