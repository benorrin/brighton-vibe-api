using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Services;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly AccountApplicationService _accountService;

    public AccountController(AccountApplicationService accountService)
    {
        _accountService = accountService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount(Guid id)
    { 
        var accountDto = await _accountService.GetAccountByIdAsync(id);
        
        if (accountDto is null)
        {
            return NotFound();
        }
        
        return Ok(accountDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _accountService.AddAccountAsync(accountDto);
        
        return CreatedAtAction(nameof(GetAccount), new { id = accountDto.Id }, accountDto);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] AccountDto accountDto)
    {
        if (id != accountDto.Id)
        {
            return BadRequest();
        }
        
        await _accountService.UpdateAccountAsync(accountDto);
        
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountService.DeleteAccountAsync(id);
        
        return NoContent();
    }
}