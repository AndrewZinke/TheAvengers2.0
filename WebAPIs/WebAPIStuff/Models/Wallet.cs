using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPIStuff.Models
{
	public class Wallet
	{
		//Wallet Id
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
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
		public virtual Customer Customer { get; set; }

		//Transactions that occured for this wallet
		public virtual List<Transaction> Transactions { get; set; }

		//public Wallet()
		//{
		//	//Customer = new Customer();
		//	Transactions = new List<Transaction>();
		//}
	}

	
}