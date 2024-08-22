using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Application.DTOs;

public class VenueTypeSummaryDto
{
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Venue> Venues { get; set; }
}