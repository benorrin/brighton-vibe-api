using BrightonVibe.Domain.Entities;
using System;
using System.Threading.Tasks;
using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(Guid id);
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(Guid id);
    }
}