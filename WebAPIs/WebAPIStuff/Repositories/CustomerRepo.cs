using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
    public class CustomerRepo : DbContext
    {
        public CustomerRepo()
            :base("name = DefaultString")
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}