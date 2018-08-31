using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
	public class WalletRepository : DbContext
	{
		public WalletRepository() : base("name=DefaultString")
		{
		}

		public DbSet<Wallet> Wallets { get; set; }

	}
}