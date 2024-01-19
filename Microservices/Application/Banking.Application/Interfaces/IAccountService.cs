using Banking.Application.Models;
using Banking.Domain.Models;

namespace Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
