
namespace Demo.BusinessLayer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Demo.BusinessLayer.DbContexts;
    using Demo.BusinessLayer.Models;
    using src.Interfaces;

    public class EmployeeService : IEmployeeService
    {
        private DemoDbContext _Conetxt;
        public EmployeeService(DemoDbContext conetxt)
        {
            this._Conetxt = conetxt;
        }

        public IEnumerable<Employees> GetEmployees()
        {
            return this._Conetxt.Employees.ToList();
        }

        public bool IsOK()
        {
            return false;
        }
    }
}