using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;

namespace BrightonVibe.Domain.Services
{
    public class AccountDomainService : IAccountDomainService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountDomainService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public async Task CreateAccountAsync(Account account)
        {
            // Domain logic for creating an account
            await _accountRepository.AddAccountAsync(account);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            // Domain logic for updating an account
            await _accountRepository.UpdateAccountAsync(account);
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            // Domain logic for deleting an account
            await _accountRepository.DeleteAccountAsync(id);
        }
    }
}