using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
    }

}