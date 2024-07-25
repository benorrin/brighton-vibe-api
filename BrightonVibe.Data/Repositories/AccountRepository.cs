using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BrightonVibe.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            var accountEntity = await _context.Accounts.FindAsync(id);
            if (accountEntity == null)
            {
                return null; // or throw an exception depending on your needs
            }
            return _mapper.Map<Account>(accountEntity);
        }
        
        public async Task AddAccountAsync(Account account)
        {
            var accountEntity = _mapper.Map<AccountEntity>(account);
            await _context.Accounts.AddAsync(accountEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var accountEntity = _mapper.Map<AccountEntity>(account);
            _context.Accounts.Update(accountEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            var accountEntity = await _context.Accounts.FindAsync(id);
            if (accountEntity != null)
            {
                _context.Accounts.Remove(accountEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}