using System.ComponentModel.DataAnnotations;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities;

public class VenueImageEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid VenueId { get; set; }
    
    [Url]
    [MaxLength(100)]
    public string? ImageUrl { get; set; }
    
    public bool Featured { get; set; }
    
    public DateTime CreatedAt { get; set; }
}