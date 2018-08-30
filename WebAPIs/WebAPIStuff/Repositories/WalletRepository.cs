using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockApplication.Models
{
	public class WalletRepository : DbContext
	{
		public WalletRepository() : base("name=DefaultString")
		{
		}

		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Customer> Customers { get; set; }

	}
}