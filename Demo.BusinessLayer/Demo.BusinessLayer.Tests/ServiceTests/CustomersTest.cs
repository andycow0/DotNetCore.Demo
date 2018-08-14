using System.Linq;
using Demo.BusinessLayer.DbContexts;
using Demo.BusinessLayer.Models;
using Demo.BusinessLayer.Services;
using NUnit.Framework;

namespace Demo.BusinessLayer.Tests.ServiceTests {
    [TestFixture]
    public class CustomersTests {
        private CustomersService _CustomersService;
        private DemoDbContext _Conetxt = new DemoDbContext ();

        [SetUp]
        public void SetUp () {
            _CustomersService = new CustomersService (_Conetxt);
        }

        [Test]
        public void GetCustomersTest () {
            var result = _CustomersService.GetCustomers ();

            Assert.IsTrue (result.Count () > 0);
        }

        [Test]
        public void GetCustomersByIdTest () {
            var result = _CustomersService.GetCustomers ("100");

            Assert.AreEqual ("100", result.CustomerId.Trim ());
        }

        [Test]
        public void DeleteCustomersByIdTest () {

            var expected = true;
            var newRecord = new Customers () {
                CustomerId = "100",
                CompanyName = "Test Company 100",
                ContactName = "Test_Man"
            };
            _CustomersService.AddRecord (newRecord);

            var result = _CustomersService.RemoveRecord ("100");

            Assert.AreEqual (expected, result);
        }
    }
}