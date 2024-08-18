using System.ComponentModel.DataAnnotations;

namespace BrightonVibe.Data.Entities;

public class AccountEntity
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string EmailAddress { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}