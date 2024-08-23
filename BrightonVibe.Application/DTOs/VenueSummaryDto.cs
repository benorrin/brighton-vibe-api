using BrightonVibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightonVibe.Application.DTOs;

public class VenueSummaryDto
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public VenueTypeDto VenueType { get; set; }
    public VenueCategoryDto VenueCategory { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
    public IEnumerable<VenueImage> VenueImages { get; set; }
    public IEnumerable<VenueOpeningHour> VenueOpeningHours { get; set; }
    public IEnumerable<VenueCardDto> SimilarVenues { get; set; }

}
