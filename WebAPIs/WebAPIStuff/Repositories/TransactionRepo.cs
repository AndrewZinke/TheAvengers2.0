
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
    public class TransactionRepo : DbContext
    {
        public TransactionRepo()
            :base ("name=DefaultString")
        {

        }

        public DbSet<Transaction> Transactions;

    }

}