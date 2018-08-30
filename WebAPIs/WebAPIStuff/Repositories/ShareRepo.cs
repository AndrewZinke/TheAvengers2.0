using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
    public class ShareRepo : DbContext
    {
        public ShareRepo() : base("name=DefaultString")
        {

        }

        public DbSet<Share> Shares { get; set; }

        public System.Data.Entity.DbSet<WebAPIStuff.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<WebAPIStuff.Models.Stock> Stocks { get; set; }

        //public System.Data.Entity.DbSet<StockExchange.Models.Stock> Stocks { get; set; }
    }
}