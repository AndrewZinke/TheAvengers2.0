using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
    public class StockDb : DbContext
    {
        public StockDb()
            :base("name=DefaultString")
        {

        }

        public DbSet<Customer> Customers { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<Share> Shares { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
	}
}