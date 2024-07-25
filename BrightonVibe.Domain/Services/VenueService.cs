using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;

namespace BrightonVibe.Domain.Services;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;

    public VenueService(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<Venue> GetVenueByIdAsync(Guid id)
    {
        return await _venueRepository.GetVenueByIdAsync(id);
    }

    public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        return await _venueRepository.GetAllVenuesAsync();
    }

    public async Task CreateVenueAsync(Venue Venue)
    {
        await _venueRepository.AddVenueAsync(Venue);
    }

    public async Task UpdateVenueAsync(Venue Venue)
    {
        await _venueRepository.UpdateVenueAsync(Venue);
    }

    public async Task DeleteVenueAsync(Guid id)
    {
        await _venueRepository.DeleteVenueAsync(id);
    }
}