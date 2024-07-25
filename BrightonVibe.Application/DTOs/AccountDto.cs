namespace BrightonVibe.Application.DTOs;

public class AccountDto
{
    public Guid Id { get; set; }
    public string EmailAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}