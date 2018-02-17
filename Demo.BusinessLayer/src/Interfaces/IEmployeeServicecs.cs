using System.Collections.Generic;
using Demo.BusinessLayer.Models;

namespace src.Interfaces
{
    public interface IEmployeeService
    {
         bool IsOK();

         IEnumerable<Employees> GetEmployees();
    }
}