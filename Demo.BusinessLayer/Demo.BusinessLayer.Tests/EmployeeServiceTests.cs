using System.Linq;
using Demo.BusinessLayer.DbContexts;
using Demo.BusinessLayer.Services;
using NUnit.Framework;

namespace Demo.BusinessLayer.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private DemoDbContext _Conetxt = new DemoDbContext();

        [SetUp]
        public void SetUp()
        {
            _employeeService = new EmployeeService(_Conetxt);
        }

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _employeeService.GetEmployees();

            Assert.IsTrue(result.Count() > 0);
        }
    }
}