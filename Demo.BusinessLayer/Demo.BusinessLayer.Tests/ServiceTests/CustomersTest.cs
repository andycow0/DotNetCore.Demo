using System.Linq;
using Demo.BusinessLayer.DbContexts;
using Demo.BusinessLayer.Services;
using NUnit.Framework;

namespace Demo.BusinessLayer.Tests.ServiceTests
{
    [TestFixture]
    public class CustomersTests
    {
        private CustomersService _CustomersService;
        private DemoDbContext _Conetxt = new DemoDbContext();

        [SetUp]
        public void SetUp()
        {
            _CustomersService = new CustomersService(_Conetxt);
        }

        [Test]
        public void GetCustomersTest()
        {
            var result = _CustomersService.GetCustomers();

            Assert.IsTrue(result.Count() > 0);
        }

        [Test]
        public void GetCustomersByIdTest()
        {
            var result = _CustomersService.GetCustomers("100");

            Assert.AreEqual("100", result.CustomerId.Trim());
        }
    }
}