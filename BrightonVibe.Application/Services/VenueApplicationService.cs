using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;

namespace BrightonVibe.Application.Services;

public class VenueApplicationService
{
    private readonly IVenueRepository _venueRepository;
    private readonly IVenueTypeRepository _venueTypeRepository;
    private readonly IVenueCategoryRepository _venueCategoryRepository;
    private readonly IVenueImageRepository _venueImageRepository;
    private readonly IVenueOpeningHourRepository _venueOpeningHourRepository;

    public VenueApplicationService(
        IVenueRepository venueRepository,
        IVenueCategoryRepository venueCategoryRepository,
        IVenueTypeRepository venueTypeRepository,
        IVenueImageRepository venueImageRepository,
        IVenueOpeningHourRepository venueOpeningHourRepository)
    {
        _venueRepository = venueRepository;
        _venueCategoryRepository = venueCategoryRepository;
        _venueTypeRepository = venueTypeRepository;
        _venueImageRepository = venueImageRepository;
        _venueOpeningHourRepository = venueOpeningHourRepository;
    }

    /// <summary>
    /// Asynchronously retrieves a venue summary by its slug, including its type, category, 
    /// and similar venues. Throws exceptions if the venue, its type, or category is not found.
    /// Maps the venue details into a VenueSummaryDto and returns it.
    /// </summary>
    /// <param name="venueSlug">The slug of the venue to be retrieved.</param>
    /// <returns>A task containing the VenueSummaryDto with venue details.</returns>
    /// <exception cref="VenueNotFoundException">Thrown if the venue is not found.</exception>
    /// <exception cref="VenueTypeNotFoundException">Thrown if the venue type is not found.</exception>
    /// <exception cref="VenueCategoryNotFoundException">Thrown if the venue category is not found.</exception>
    public async Task<VenueSummaryDto> GetVenueSummaryBySlugAsync(string venueSlug)
    {
        // Get Venue
        var venue = await _venueRepository.GetVenueBySlugAsync(venueSlug);
        
        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        // Get VenueType
        var venueType = await _venueTypeRepository.GetVenueTypeByIdAsync(venue.VenueTypeId);

        if (venue is null)
        {
            throw new VenueTypeNotFoundException();
        }

        var venueTypeDto = new VenueTypeDto
        {
            Slug = venueType.Slug,
            Name = venueType.Name,
            Description = venueType.Description
        };

        // Get VenueCategory
        var venueCategory = await _venueCategoryRepository.GetVenueCategoryByIdAsync(venueType.VenueCategoryId);

        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        var venueCategoryDto = new VenueCategoryDto
        {
            Slug = venueCategory.Slug,
            Name = venueCategory.Name,
            Description = venueCategory.Description
        };

        // Get similar Venues
        var similarVenues = await _venueRepository.GetVenuesByTypeIdAsync(venueType.Id, 4);

        var similarVenuesDto = similarVenues
            .Select(venue => new VenueCardDto
            {
                Slug = venue.Slug,
                Name = venue.Name,
                VenueImages = venue.VenueImages
            });

        var venueDto = new VenueSummaryDto
        {
            Id = venue.Id,
            Slug = venue.Slug,
            Name = venue.Name,
            VenueType = venueTypeDto,
            VenueCategory = venueCategoryDto,
            Summary = venue.Summary,
            Description = venue.Description,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            EmailAddress = venue.EmailAddress,
            Website = venue.Website,
            Instagram = venue.Instagram,
            Facebook = venue.Facebook,
            VenueImages = venue.VenueImages,
            VenueOpeningHours = venue.VenueOpeningHours,
            SimilarVenues = similarVenuesDto
        };

        return venueDto;
    }

    /// <summary>
    /// Asynchronously retrieves a list of venues by their type ID. 
    /// If no venues are found, a VenueNotFoundException is thrown.
    /// </summary>
    /// <param name="venueTypeId">The ID of the venue type to filter venues by.</param>
    /// <returns>A task containing an IEnumerable of Venue objects.</returns>
    /// <exception cref="VenueNotFoundException">Thrown if no venues are found for the given type ID.</exception>
    public async Task<IEnumerable<Venue>> GetVenuesByTypeIdAsync(Guid venueTypeId)
    {
        var venues = await _venueRepository.GetVenuesByTypeIdAsync(venueTypeId);
        
        if (venues.Count() == 0)
        {
            throw new VenueNotFoundException();
        }

        return venues;
    }

}