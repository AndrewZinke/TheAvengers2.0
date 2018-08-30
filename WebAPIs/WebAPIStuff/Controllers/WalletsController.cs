using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StockApplication.Models;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace StockApplication.Controllers
{
	[DataContract(Name = "Wallets")]
	public class WalletsController : ApiController
    {
        private WalletRepository db = new WalletRepository();

       /* // GET: api/Wallets
        public IQueryable<Wallet> GetWallets()
        {
            return db.Wallets.AsQueryable();
		}
		*/

        // GET: api/Wallets/5
		// GET current logged in custoer's wallet
        [ResponseType(typeof(Wallet))]
        public IHttpActionResult GetWallet(int id)
        {
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return NotFound();
            }

            return Ok(wallet);
        }

		// PUT: api/Wallet/5
		// PUT: Update the wallet's balance, Active State
		[ResponseType(typeof(void))]
        public IHttpActionResult PutWallet(int id, Wallet wallet)
        {
			if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			Debug.WriteLine(wallet.Id);
            if (id != wallet.Id)
            {
                return BadRequest();
            }

			Debug.WriteLine("Wallet Id Count: " + db.Wallets.Count());
			Debug.WriteLine("Wallet Id: " + wallet.Id);
			Debug.WriteLine("Wallet CustomerId: " + wallet.CustomerId);
			Debug.WriteLine("Wallet Balance: " + wallet.Balance);
			Debug.WriteLine("Wallet Activite: " + wallet.IsActive);

			db.Entry(wallet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

		// POST: api/Wallets
		// POST a new wallet if it does not exist for current logged in customer
		[ResponseType(typeof(Wallet))]
        public IHttpActionResult PostWallet(Wallet wallet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			//Manually autoincrement wallet id
			wallet.Id = db.Wallets.Count() + 1;

			db.Wallets.Add(wallet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wallet.Id }, wallet);
        }

		// POST: api/Wallet
		// POST a new transaction corresponding to wallet operations for current logged in customer
		[HttpPost]
		[Route("api/Transaction")]
		[ResponseType(typeof(Transaction))]
		public IHttpActionResult PostWalletTransaction(Transaction transaction)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Debug.WriteLine("Transaction TransactionId: " + transaction.Id);
			Debug.WriteLine("Transaction CustomerId: " + transaction.CustomerId);
			Debug.WriteLine("Transaction WalletId: " + transaction.WalletId);
			Debug.WriteLine("Transaction Description: " + transaction.Descr);
			Debug.WriteLine("Transaction Amount: " + transaction.Amount);
			db.Transactions.Add(transaction);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
		}

		// DELETE: api/Wallets/5
		/*[ResponseType(typeof(Wallet))]
        public IHttpActionResult DeleteWallet(int id)
        {
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return NotFound();
            }

            db.Wallets.Remove(wallet);
            db.SaveChanges();

            return Ok(wallet);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WalletExists(int id)
        {
            return db.Wallets.Count(e => e.Id == id) > 0;
        }
    }
}