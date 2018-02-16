using Demo.BusinessLayer.Services;
using NUnit.Framework;
using src.Interfaces;

namespace Demo.BusinessLayer.Services.Tests
{
    [TestFixture]
    public class EmpoyeeTests
    {
        private IEmployeeService _EmployeeService { get; set; }

        [SetUp]
        public void Setup()
        {
            this._EmployeeService = new EmployeeService();
        }

        [Test]
        public void Test1()
        {
            // var expect = false;
            var result = this._EmployeeService.IsOK();

            Assert.IsTrue(result, "EmplyeeService IsOK return true!");
        }
    }
}