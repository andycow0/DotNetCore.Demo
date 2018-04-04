using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}