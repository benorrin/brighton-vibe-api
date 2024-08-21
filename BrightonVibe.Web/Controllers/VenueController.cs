using Microsoft.AspNetCore.Mvc;
using BrightonVibe.Application.Services;

[ApiController]
[Route("venues")]
public class VenueController : ControllerBase
{
    private readonly VenueApplicationService _venueApplicationService;

    public VenueController(VenueApplicationService venueService)
    {
        _venueApplicationService = venueService;
    }

    [HttpGet("{venueSlug}")]
    public async Task<IActionResult> GetVenueByIdAsync(string venueSlug)
    { 
        var venueDto = await _venueApplicationService.GetVenueBySlugAsync(venueSlug);
        
        return Ok(venueDto);
    }
    
    [HttpGet("type/{venueTypeId:guid}")]
    public async Task<IActionResult> GetVenuesByTypeIdAsync(Guid venueTypeId)
    {
        var venues = await _venueApplicationService.GetVenuesByTypeIdAsync(venueTypeId);

        return Ok(venues);
    }

}