
namespace Demo.BusinessLayer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Demo.BusinessLayer.DbContexts;
    using Demo.BusinessLayer.Models;
    using Microsoft.Extensions.Logging;
    using src.Interfaces;

    public class EmployeeService : IEmployeeService
    {
        private DemoDbContext _Conetxt;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(DemoDbContext conetxt)
        {
            this._Conetxt = conetxt;
        }
        public EmployeeService(ILogger<EmployeeService> logger)
        {
            this._logger = logger;
        }

        public bool AddRecord(Employees employee)
        {
            this._Conetxt.Employees.Add(employee);

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