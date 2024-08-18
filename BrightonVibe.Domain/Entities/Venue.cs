using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class Venue
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public VenueCategory Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
    
}