using Microsoft.AspNetCore.Mvc;
using BrightonVibe.Application.Services;

[ApiController]
[Route("venue-types")]
public class VenueTypeController : ControllerBase
{
    private readonly VenueTypeApplicationService _venueTypeApplicationService;

    public VenueTypeController(VenueTypeApplicationService venueTypeApplicationService)
    {
        _venueTypeApplicationService = venueTypeApplicationService;
    }

    [HttpGet("{venueTypeSlug}/summary")]
    public async Task<IActionResult> GetVenueTypeSummaryBySlugAsync(string venueTypeSlug)
    { 
        var venueTypeSummaryDto = await _venueTypeApplicationService.GetVenueTypeSummaryBySlugAsync(venueTypeSlug);
        
        return Ok(venueTypeSummaryDto);
    }

}