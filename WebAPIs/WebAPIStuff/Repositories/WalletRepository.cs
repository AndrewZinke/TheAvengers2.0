using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
	public class WalletRepository
	{
		private StockDb _db = new StockDb();

		public Wallet GetWallet(int id)
		{
			var wallet = _db.Wallets.Find(id);
			return wallet;
		}

		public IList<Wallet> GetWallets()
		{
			var wallets = _db.Wallets.ToList<Wallet>();
			return wallets;
		}

		public void PutWallet(int id, Wallet wallet)
		{
			_db.Entry(wallet).State = EntityState.Modified;
			_db.SaveChanges();

		}


	}
}