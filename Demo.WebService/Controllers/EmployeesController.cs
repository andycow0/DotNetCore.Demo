using System;
using System.Collections.Generic;
using Demo.BusinessLayer.Models;
using Demo.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Interfaces;

namespace Demo.WebService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController
    {
        private readonly IEmployeeService _EmployeeService;
        private readonly ILogger _Logger;
        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            this._Logger = logger;
            this._EmployeeService = employeeService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            _Logger.LogTrace($"This is trace log. {DateTime.Now}");
            _Logger.LogDebug($"This is Debug log. {DateTime.Now:yyyyMMdd HH:mm}");
            _Logger.LogError($"This is Error log. {DateTime.Now:yyyyMMdd HH:mm}");
            _Logger.LogInformation($"This is Info log. {DateTime.Now:yyyyMMdd HH:mm}");
            _Logger.LogWarning($"This is Warning log. {DateTime.Now:yyyyMMdd HH:mm}");
            _Logger.LogCritical($"This is Critical log. {DateTime.Now:yyyyMMdd HH:mm}");
            // var result = this._EmployeeService.GetEmployees();

            var result = new List<Employees>()
            {
                new Employees(){
                    FirstName ="測試123456",
                    LastName ="Aa",
                    BirthDate=DateTime.Now.AddDays(-1)
                },
                new Employees(){
                    FirstName ="Test2",
                    LastName ="Bb",
                    BirthDate=DateTime.Now.AddDays(-2)
                },

                new Employees(){
                    FirstName ="Test3",
                    LastName ="Cc",
                    BirthDate=DateTime.Now.AddDays(-3)
                },
            };

            return result;
        }
    }
}