
namespace Demo.BusinessLayer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Demo.BusinessLayer.DbContexts;
    using Demo.BusinessLayer.Models;
    using Microsoft.Extensions.Logging;
    using src.Interfaces;

    public class CustomersService : ICustomersService
    {
        private DemoDbContext _Conetxt;
        public CustomersService(DemoDbContext conetxt)
        {
            this._Conetxt = conetxt;
        }

        public bool AddRecord(Customers customers)
        {
            this._Conetxt.Customers.Add(customers);

            var recordNums = this._Conetxt.SaveChanges();

            if (recordNums > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Customers> GetCustomers()
        {
            return this._Conetxt.Customers.ToList();
        }

        public Customers GetCustomers(string customerId)
        {
            return this._Conetxt.Customers.SingleOrDefault(c => c.CustomerId == customerId);
        }

        public bool IsOK()
        {
            return false;
        }
    }
}