using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Domain.Enums;
using BrightonVibe.Domain.Services;

namespace BrightonVibe.Application.Services;

public class VenueApplicationService
{
    private readonly IVenueService _venueService;
    private readonly IMapper _mapper;
    private readonly IVenueRepository _venueRepository;

    public VenueApplicationService(
        IVenueService venueService, 
        IMapper mapper,
        IVenueRepository venueRepository)
    {
        _venueService = venueService;
        _mapper = mapper;
        _venueRepository = venueRepository;
    }

    public async Task<VenueDto> GetVenueByIdAsync(Guid id)
    {
        var venue = await _venueService.GetVenueByIdAsync(id);

        // Check if the venue exists
        if (venue == null)
        {
            // Handle the case where the venue is not found (return null, throw an exception, etc.)
            // Example: throw new NotFoundException("Venue not found");
            return null; // Adjust according to your error handling strategy
        }
        
        var venueDto = new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Type = venue.Type,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            EmailAddress = venue.EmailAddress,
            Website = venue.Website,
            Instagram = venue.Instagram,
            Facebook = venue.Facebook
        };
        
        return venueDto;
    }

    public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
    {
        var venues = await _venueService.GetAllVenuesAsync();
        
        return venues
            .Select(v => _mapper.Map<VenueDto>(v));
    }

    public async Task<IEnumerable<VenueDto>> GetPaginatedVenuesAsync(int pageNumber)
    {
        var pageSize = 10;
        
        var venues = await _venueRepository.GetAllVenuesAsync();

        var paginatedVenuesQuery = venues
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        
        var paginatedVenues = paginatedVenuesQuery
            .Select(v => new VenueDto
            {
                Id = v.Id,
                Name = v.Name,
                Type = v.Type,
                Address = v.Address,
                PhoneNumber = v.PhoneNumber,
                EmailAddress = v.EmailAddress,
                Website = v.Website,
                Instagram = v.Instagram,
                Facebook = v.Facebook
            })
            .ToList();

        return paginatedVenues;
    }
    
    public async Task<IEnumerable<VenueDto>> GetVenuesByTypeAsync(VenueType venueType)
    {
        var venues = await _venueRepository.GetVenuesByTypeAsync(venueType);

        return venues.Select(v => _mapper.Map<VenueDto>(v));
    }

    public async Task AddVenueAsync(VenueDto venueDto)
    {
        var venue = _mapper.Map<Venue>(venueDto);
        await _venueService.CreateVenueAsync(venue);
    }

    public async Task UpdateVenueAsync(VenueDto venueDto)
    {
        var venue = _mapper.Map<Venue>(venueDto);
        await _venueService.UpdateVenueAsync(venue);
    }

    public async Task DeleteVenueAsync(Guid id)
    {
        await _venueService.DeleteVenueAsync(id);
    } 
}