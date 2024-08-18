using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class VenueEntity
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public VenueType Type { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    
    [Phone]
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
    
    [EmailAddress]
    [MaxLength(100)]
    public string? EmailAddress { get; set; }
    
    [Url]
    [MaxLength(100)]
    public string? Website { get; set; }
    
    [Url]
    [MaxLength(100)]
    public string? Instagram { get; set; }
    
    [Url]
    [MaxLength(100)]
    public string? Facebook { get; set; }
}