namespace BrightonVibe.Application.DTOs;

public class VenueCategorySummaryDto
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<VenueTypeSummaryDto> VenueTypes { get; set; }
}