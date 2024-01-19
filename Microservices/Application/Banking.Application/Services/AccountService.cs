using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Domain.Core.Bus;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IEventBus _bus;


        public AccountService(IAccountRepository repository, IEventBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount);

            _bus.SendCommand(createTransferCommand);
        }
    }
}
