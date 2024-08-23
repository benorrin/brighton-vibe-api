using BrightonVibe.Domain.Entities;

namespace BrightonVibe.Application.DTOs;

public class VenueTypeSummaryDto
{
    public required string Slug { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required IEnumerable<VenueCardDto> Venues { get; set; }
}