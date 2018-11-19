using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebSite.Controllers.Api {

    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        HttpClient client = new HttpClient ();
        public CustomersController () { }

        [HttpGet]
        public IEnumerable<string> Get () {
            return new List<string> () {
                "value1",
                "value2",
                "value3"
            };
        }

        [HttpGet ("GetAllCustomers")]
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync () {
            IEnumerable<Customer> customers = null;
            var response = await client.GetAsync ("https://dotnetcoredemo-217516.appspot.com/api/Customers");
            if (response.IsSuccessStatusCode) {
                customers = await response.Content.ReadAsAsync<List<Customer>> ();
            } else {
                customers = new List<Customer> ();
            }
            return customers;
        }

        [HttpDelete ("{id}")]
        public ResultModel Delete (string id) {

            var result = new ResultModel ();

            var request = client.DeleteAsync ("https://dotnetcoredemo-217516.appspot.com/api/Customers/" + id);

            var response = request.Result;

            if (response.IsSuccessStatusCode) {
                result.IsSuccess = true;
            } else {
                result.Message = response.IsSuccessStatusCode.ToString ();
            }

            return result;
        }
    }

}