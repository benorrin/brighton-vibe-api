using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities;

public class VenueEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public VenueType Type { get; set; }
    public string Address { get; set; }
    public IEnumerable<string> ImagePaths { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
}