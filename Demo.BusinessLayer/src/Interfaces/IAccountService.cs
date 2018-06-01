using System.Collections.Generic;

namespace Demo.BusinessLayer.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<string> GetAllAccounts();
    }
}