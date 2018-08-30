using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StockApplication.Models
{
	public class Wallet
	{
		//Wallet Id
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key]
		public int Id { get; set; }

		//Customer Id who owns this wallet 
		public int? CustomerId { get; set; }

		//Amount of Money available in this wallet
		public double? Balance { get; set; }

		//State of Wallet {Active Wallet/Inactive Wallet}
		public bool IsActive { get; set; }

		//Customer details for this wallet
		//[Required]
		//NOTE: When I post a new wallet, a new customer is added to the customer table...strange behavior; 
		//public virtual Customer Customer { get; set; }

		//Transactions that occured for this wallet
		public virtual List<Transaction> Transactions { get; set; }

		public Wallet()
		{
			//Customer = new Customer();
			Transactions = new List<Transaction>();
		}
	}

	//Delete this from wallet Class once we gain access to customer and transaction class from Lance and Andrew
	public class Customer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool IsActive { get; set; }
		public string Email { get; set; }
		
		public virtual Wallet MyWallet { get; set; }
		public virtual List<Share> Shares { get; set; }

		public Customer()
		{
			this.Shares = new List<Share>();
		}
	}
	public class Transaction
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key]
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public int? WalletId { get; set; }
		public string Descr { get; set; }
		public double? Amount { get; set; }
	}
	public class Share
	{
		[Key]
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public int? StockId { get; set; }
		public double? Price { get; set; }
	}
	public class Stock
	{
		[Key]
		public int Id { get; set; }
		public string Symbol { get; set; }
		public double? Price { get; set; }
		public int? AmountOfShares { get; set; }
		public double? Change { get; set; }
		public double? PercentChange { get; set; }
		public double? Low { get; set; }
		public double? High { get; set; }
	}
}