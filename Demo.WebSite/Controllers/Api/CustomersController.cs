using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebSite.Controllers.Api {

    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        [HttpGet]
        public IEnumerable<string> Get () {
            return new List<string> () {
                "value1",
                "value2",
                "value3"
            };
        }
    }
}