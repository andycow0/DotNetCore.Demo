using System.Collections.Generic;
using Demo.BusinessLayer.Models;
using Demo.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using src.Interfaces;

namespace Demo.WebService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this._EmployeeService = employeeService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            var result = this._EmployeeService.GetEmployees();
            return result;
        }
    }
}