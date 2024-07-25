using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces;

public interface IAccountService
{
    Task<Account> GetAccountByIdAsync(Guid id);
    Task CreateAccountAsync(Account account);
    Task UpdateAccountAsync(Account account);
    Task DeleteAccountAsync(Guid id);
}