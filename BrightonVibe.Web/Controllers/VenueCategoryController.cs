using Microsoft.AspNetCore.Mvc;
using BrightonVibe.Application.Services;

[ApiController]
[Route("venue-categories")]
public class VenueCategoryController : ControllerBase
{
    private readonly VenueCategoryApplicationService _venueCategoryApplicationService;

    public VenueCategoryController(VenueCategoryApplicationService venueCategoryApplicationService)
    {
        _venueCategoryApplicationService = venueCategoryApplicationService;
    }

    [HttpGet("{venueCategoryId:guid}")]
    public async Task<IActionResult> GetVenueCategoryByIdAsync(Guid venueCategoryId)
    { 
        var venueDto = await _venueCategoryApplicationService.GetVenueCategoryByIdAsync(venueCategoryId);
        
        return Ok(venueDto);
    }

}