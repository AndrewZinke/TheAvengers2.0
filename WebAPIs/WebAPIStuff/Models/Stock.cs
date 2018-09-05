using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIStuff.Models
{
    public class Stock
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Price Per Share")]
        public decimal PPS { get; set; }
        [Display(Name = "Symbol")]
        public string symbol { get; set; }
        [Display(Name = "Low")]
        public decimal low { get; set; }
        [Display(Name = "High")]
        public decimal high { get; set; }
        [Display(Name = "Shares")]
        public int shares { get; set; }

        //public Stock()
        //{

        //}

<<<<<<< HEAD
        //public void addShare(Share share)
        //{
        //    shares.Add(share);
        //}
=======
        public void sellShare()
        {
            shares--;
        }
>>>>>>> f5503442ca127883fd584267b5d973bc99abadb3
    }
}