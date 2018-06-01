namespace Demo.BusinessLayer.Services
{
    using System.Collections.Generic;
    using Demo.BusinessLayer.Interfaces;

    public class AccountService : IAccountService
    {
        public IEnumerable<string> GetAllAccounts()
        {
            return new List<string>() { "value1", "value2", "value3" };
        }
    }
}