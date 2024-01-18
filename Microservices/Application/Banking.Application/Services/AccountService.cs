using Banking.Application.Interfaces;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }
    }
}
