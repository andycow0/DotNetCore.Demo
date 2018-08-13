using System;
using System.Collections.Generic;
using Demo.BusinessLayer.Models;
using Demo.BusinessLayer.Services;
using Demo.WebService.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Interfaces;

namespace Demo.WebService.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController
    {
        private readonly ICustomersService _CustomerService;
        private readonly ILogger _Logger;
        public CustomersController(ILogger<CustomersController> logger, ICustomersService CustomerService)
        {
            this._Logger = logger;
            this._CustomerService = CustomerService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            var result = this._CustomerService.GetCustomers();

            return result;
        }

        [HttpGet("{id}")]
        public ResultModel Get(string id)
        {
            var result = new ResultModel();
            result.Data = _CustomerService.GetCustomers(id);
            result.IsSuccess = true;
            return result;
        }

        [HttpPost]
        public ResultModel Post([FromBody]Customers customer)
        {
            var result = new ResultModel()
            {
                Data = customer.CompanyName
            };
            try
            {
                var requestResult = this._CustomerService.AddRecord(customer);

                result.IsSuccess = requestResult;
                result.Message = requestResult ? string.Empty : "Add request wasn't successful!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}