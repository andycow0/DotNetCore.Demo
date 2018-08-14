namespace Demo.BusinessLayer.Services {
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Demo.BusinessLayer.DbContexts;
    using Demo.BusinessLayer.Models;
    using Microsoft.Extensions.Logging;
    using src.Interfaces;

    public class CustomersService : ICustomersService {
        private DemoDbContext _Conetxt;
        public CustomersService (DemoDbContext conetxt) {
            this._Conetxt = conetxt;
        }

        public bool AddRecord (Customers customers) {
            this._Conetxt.Customers.Add (customers);

            var recordNums = this._Conetxt.SaveChanges ();

            if (recordNums > 0) {
                return true;
            } else {
                return false;
            }
        }

        public IEnumerable<Customers> GetCustomers () {
            return this._Conetxt.Customers.ToList ();
        }

        public Customers GetCustomers (string customerId) {
            return this._Conetxt.Customers.SingleOrDefault (c => c.CustomerId == customerId);
        }

        public bool RemoveRecord (string customerId) {

            var result = true;
            var customer = this._Conetxt.Customers.SingleOrDefault (c => c.CustomerId == customerId);

            if (customer != null) {
                this._Conetxt.Customers.Remove (customer);
                result = this._Conetxt.SaveChanges () > 0 ? true : false;
            } else {
                result = false;
            }

            return result;
        }

        public bool IsOK () {
            return false;
        }
    }
}