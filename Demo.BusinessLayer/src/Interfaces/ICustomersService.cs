using System.Collections.Generic;
using Demo.BusinessLayer.Models;

namespace src.Interfaces {
    public interface ICustomersService {
        bool IsOK ();

        IEnumerable<Customers> GetCustomers ();

        Customers GetCustomers (string customerId);
        bool AddRecord (Customers customers);
        bool RemoveRecord(string customerId);
    }
}