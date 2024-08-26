using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace BrightonVibe.Application.Services;

public class VenueTypeApplicationService
{
    private readonly IVenueTypeRepository _venueTypeRepository;
    private readonly IVenueCategoryRepository _venueCategoryRepository;
    private readonly IVenueRepository _venueRepository;

    public VenueTypeApplicationService(
        IVenueTypeRepository venueTypeRepository,
        IVenueCategoryRepository venueCategoryRepository,
        IVenueRepository venueRepository)
    {
        _venueTypeRepository = venueTypeRepository;
        _venueCategoryRepository = venueCategoryRepository;
        _venueRepository = venueRepository;
    }

    /// <summary>
    /// Asynchronously retrieves a detailed summary of a <see cref="VenueType"/> by its slug identifier.
    /// </summary>
    /// <param name="venueTypeSlug">The unique slug that identifies the venue type.</param>
    /// <returns>
    /// A <see cref="VenueTypeSummaryDto"/> containing comprehensive information about the venue type,
    /// including its category and associated venues.
    /// </returns>
    /// <exception cref="VenueTypeNotFoundException">
    /// Thrown when no venue type is found for the provided slug.
    /// </exception>
    /// <exception cref="VenueCategoryNotFoundException">
    /// Thrown when the venue category associated with the found venue type does not exist.
    /// </exception>
    public async Task<VenueTypeSummaryDto> GetVenueTypeSummaryBySlugAsync(string venueTypeSlug)
    {
        var venueType = await _venueTypeRepository.GetVenueTypeBySlugAsync(venueTypeSlug);
        
        if (venueType is null)
        {
            throw new VenueTypeNotFoundException();
        }

        var venueCategory = await _venueCategoryRepository.GetVenueCategoryByIdAsync(venueType.VenueCategoryId);

        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        var venueCategoryDto = new VenueCategoryDto
        {
            Slug = venueCategory.Slug,
            Name = venueCategory.Name,
            Description = venueCategory.Description,
        };

        var venues = await _venueRepository.GetVenuesByTypeIdAsync(venueType.Id);

        var venueCards = venues
            .Select(venue => new VenueCardDto {
                Slug = venue.Slug,
                Name = venue.Name,
                CreatedAt = venue.CreatedAt,
                VenueImages = venue.VenueImages
            });

        var venueTypeSummaryDto = new VenueTypeSummaryDto
        {
            Slug = venueType.Slug,
            Name = venueType.Name,
            Description = venueType.Description,
            VenueCategory = venueCategoryDto,
            Venues = venueCards
        };

        return venueTypeSummaryDto;
    }
}