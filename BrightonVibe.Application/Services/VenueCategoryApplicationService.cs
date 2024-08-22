using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;

namespace BrightonVibe.Application.Services;

public class VenueCategoryApplicationService
{
    private readonly IVenueCategoryRepository _venueCategoryRepository;
    public readonly IVenueTypeRepository _venueTypeRepository;
    public readonly IVenueRepository _venueRepository;

    public VenueCategoryApplicationService(
        IVenueCategoryRepository venueCategoryRepository,
        IVenueTypeRepository venueTypeRepository,
        IVenueRepository venueRepository)
    {
        _venueCategoryRepository = venueCategoryRepository;
        _venueTypeRepository = venueTypeRepository;
        _venueRepository = venueRepository;
    }
    
    /// <summary>
    /// Asynchronously retrieves a VenueCategory by its slug and throws an exception if not found.
    /// </summary>
    /// <param name="venueCategorySlug">The slug of the venue category to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the 
    /// <see cref="VenueCategory"/> object corresponding to the provided slug.
    /// </returns>
    /// <exception cref="VenueCategoryNotFoundException">
    /// Thrown if no venue category with the specified slug is found.
    /// </exception>
    public async Task<VenueCategory> GetVenueCategoryBySlugAsync(string venueCategorySlug)
    {
        var venueCategory = await _venueCategoryRepository.GetVenueCategoryBySlugAsync(venueCategorySlug);
        
        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        return venueCategory;
    }
    
    /// <summary>
    /// Asynchronously retrieves a summary of a venue category, including details about venue types and associated venues.
    /// </summary>
    /// <param name="venueCategorySlug">The unique slug of the venue category for which the summary is to be fetched.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is a <see cref="VenueCategorySummaryDto"/> containing the category details,
    /// a list of venue types within the category, and up to four venues for each venue type.
    /// </returns>
    /// <exception cref="VenueCategoryNotFoundException">Thrown when the venue category with the specified slug is not found.</exception>
    public async Task<VenueCategorySummaryDto> GetVenueCategorySummaryBySlugAsync(string venueCategorySlug)
    {
        // Fetch venue category
        var venueCategory = await _venueCategoryRepository.GetVenueCategoryBySlugAsync(venueCategorySlug);
        
        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        // Fetch venue types within the given category
        var venueTypes = await _venueTypeRepository.GetVenueTypesByCategoryAsync(venueCategory.Id);
        
        var venueTypesSummaryDto = new List<VenueTypeSummaryDto>();

        // Iterate through each VenueType and get 4 associated Venues
        foreach (var venueType in venueTypes)
        {
            var venues = await _venueRepository.GetVenuesByTypeIdAsync(venueType.Id, 4);

            var venueTypeSummaryDto = new VenueTypeSummaryDto
            {
                Slug = venueType.Slug,
                Name = venueType.Name,
                Description = venueType.Description,
                Venues = venues
            };
            
            venueTypesSummaryDto.Add(venueTypeSummaryDto);
        }

        // Compile all elements into the VenueCategorySummaryDto
        var venueCategorySummaryDto = new VenueCategorySummaryDto
        {
            Id = venueCategory.Id,
            Slug = venueCategory.Slug,
            Name = venueCategory.Name,
            Description = venueCategory.Description,
            VenueTypes = venueTypesSummaryDto
        };

        return venueCategorySummaryDto;
    }
}