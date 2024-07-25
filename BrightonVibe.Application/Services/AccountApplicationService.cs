using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Domain.Services;

namespace BrightonVibe.Application.Services;

public class AccountApplicationService
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountApplicationService(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetAccountByIdAsync(Guid id)
    {
        var account = await _accountService.GetAccountByIdAsync(id);
        return _mapper.Map<AccountDto>(account);
    }

    public async Task AddAccountAsync(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        await _accountService.CreateAccountAsync(account);
    }

    public async Task UpdateAccountAsync(AccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        await _accountService.UpdateAccountAsync(account);
    }

    public async Task DeleteAccountAsync(Guid id)
    {
        await _accountService.DeleteAccountAsync(id);
    } 
}