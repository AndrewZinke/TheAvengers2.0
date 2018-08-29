using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIStuff.Models;

namespace WebAPIStuff.Controllers
{
    public class CustomersController : ApiController
    {
        //creates a list of customers to use in the methods
        private Repositories.CustomerRepo _customerRepo = new Repositories.CustomerRepo();

        // GET: api/Customers
        public IEnumerable<Customer> Get()
        { 
            return _customerRepo.Customers.ToList();
        }

        // GET: api/Customers/5
        public Customer Get(int id)
        {
            var customer = _customerRepo.Customers.ToList().Where(c => c.Id == id).First();
            return customer;
        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put([FromBody]Customer customer)
        {
            _customerRepo.Customers.Add(customer);
            _customerRepo.SaveChanges();
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
