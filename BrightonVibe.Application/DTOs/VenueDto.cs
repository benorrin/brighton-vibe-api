using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Application.DTOs;

public class VenueDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public VenueCategory Category { get; init; }
    public string Summary { get; init; }
    public string Description { get; init; }
    public IEnumerable<VenueImage?> VenueImages { get; init; }
    public IEnumerable<VenueOpeningHour?> VenueOpeningHours { get; init; }
    public string Address { get; init; }
    public string? PhoneNumber { get; init; }
    public string? EmailAddress { get; init; }
    public string? Website { get; init; }
    public string? Instagram { get; init; }
    public string? Facebook { get; init; }
}