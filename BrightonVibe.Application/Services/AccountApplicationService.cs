using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Domain.Services;

namespace BrightonVibe.Application.Services;

public class AccountApplicationService
{
    private readonly IAccountDomainService _accountDomainService;
    private readonly IMapper _mapper;

    public AccountApplicationService(IAccountDomainService accountDomainService, IMapper mapper)
    {
        _accountDomainService = accountDomainService;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetAccountByIdAsync(Guid id)
    {
        var account = await _accountDomainService.GetAccountByIdAsync(id);
        return _mapper.Map<AccountDto>(account);
    }

    public async Task AddAccountAsync(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        await _accountDomainService.CreateAccountAsync(account);
    }

    public async Task UpdateAccountAsync(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        await _accountDomainService.UpdateAccountAsync(account);
    }

    public async Task DeleteAccountAsync(Guid id)
    {
        await _accountDomainService.DeleteAccountAsync(id);
    } 
}