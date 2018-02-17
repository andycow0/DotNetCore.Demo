namespace Demo.WebApi.Site.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Demo.BusinessLayer.DbContexts;
    using Demo.BusinessLayer.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly DemoDbContext _context = new DemoDbContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<Employees> Get()
        {

            return this._context.Employees.Select(e => new Employees()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                City = e.City
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}