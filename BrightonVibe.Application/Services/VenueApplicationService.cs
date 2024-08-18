using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Enums;
using BrightonVibe.Domain.Services;

namespace BrightonVibe.Application.Services;

public class VenueApplicationService
{
    private readonly IVenueRepository _venueRepository;
    private readonly IVenueImageRepository _venueImageRepository;
    private readonly IVenueOpeningHourRepository _venueOpeningHourRepository;

    public VenueApplicationService(
        IVenueRepository venueRepository,
        IVenueImageRepository venueImageRepository,
        IVenueOpeningHourRepository venueOpeningHourRepository)
    {
        _venueRepository = venueRepository;
        _venueImageRepository = venueImageRepository;
    }

    /// <summary>
    /// Asynchronously retrieves the details of a venue by its unique identifier.
    /// 
    /// This method fetches the venue's information and associated images from the repository. 
    /// If the venue with the specified ID does not exist, it throws a <see cref="VenueNotFoundException"/>.
    /// The venue images are collected and included in the result. If there are no images associated 
    /// with the venue, the returned list of images in the <see cref="VenueDto"/> will be empty but not null.
    /// 
    /// <param name="venueId">The unique identifier of the venue to retrieve.</param>
    /// <returns>A <see cref="VenueDto"/> containing the venue details and associated images.</returns>
    /// <exception cref="VenueNotFoundException">Thrown when a venue with the specified ID is not found.</exception>
    /// </summary>
    public async Task<VenueDto> GetVenueByIdAsync(Guid venueId)
    {
        var venue = await _venueRepository.GetVenueByIdAsync(venueId);
        
        if (venue is null)
        {
            throw new VenueNotFoundException(venueId);
        }

        var venueImages = await _venueImageRepository.GetVenueImagesByVenueId(venueId);

        var venueOpeningHours = await _venueOpeningHourRepository.GetVenueOpeningHoursByVenueId(venueId);
        
        return new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Type = venue.Type,
            VenueImages = venueImages,
            VenueOpeningHours = venueOpeningHours,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            EmailAddress = venue.EmailAddress,
            Website = venue.Website,
            Instagram = venue.Instagram,
            Facebook = venue.Facebook
        };
    }
    
    public async Task<IEnumerable<Venue>> GetVenuesByTypeAsync(VenueType venueType)
    {
        var venues = await _venueRepository.GetVenuesByTypeAsync(venueType);

        return venues;
    }

}