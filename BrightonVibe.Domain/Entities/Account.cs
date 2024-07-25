namespace BrightonVibe.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Account(string emailAddress, string passwordHash)
    {
        Id = Guid.NewGuid();
        EmailAddress = emailAddress;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateEmail(string newEmailAddress)
    {
        // Add validation for email format if needed
        EmailAddress = newEmailAddress;
    }

    public void ChangePassword(string newPasswordHash)
    {
        // Add validation for password strength if needed
        PasswordHash = newPasswordHash;
    }
}