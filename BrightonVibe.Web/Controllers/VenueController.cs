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
    
    [HttpGet("category/{venueCategoryId:guid}")]
    public async Task<IActionResult> GetVenuesByCategoryIdAsync(Guid venueCategoryId)
    {
        var venues = await _venueApplicationService.GetVenuesByCategoryIdAsync(venueCategoryId);

        return Ok(venues);
    }

}