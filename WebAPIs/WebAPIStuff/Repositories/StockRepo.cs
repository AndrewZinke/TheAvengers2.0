﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIStuff.Models;

namespace WebAPIStuff.Repositories
{
    public class StockRepo : DbContext
    {
        public StockRepo() : base("name=DefaultString")
        {

        }
        public DbSet<Stock> Stocks { get; set; }
    }
}