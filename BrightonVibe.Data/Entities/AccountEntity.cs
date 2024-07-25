namespace BrightonVibe.Data.Entities;

public class AccountEntity
{
    public required Guid Id { get; set; }
    public required string EmailAddress { get; set; }
    public required string PasswordHash { get; set; }
    public required DateTime CreatedAt { get; set; }
}