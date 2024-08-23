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

    [HttpGet("{venueTypeId:guid}")]
    public async Task<IActionResult> GetVenueTypeByIdAsync(Guid venueTypeId)
    { 
        var venueDto = await _venueTypeApplicationService.GetVenueTypeByIdAsync(venueTypeId);
        
        return Ok(venueDto);
    }

}