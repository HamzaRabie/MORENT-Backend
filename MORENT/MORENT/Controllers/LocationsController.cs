using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MORENT.Services.Interfaces;

namespace MORENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService _locationService)
        {
            this._locationService = _locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }
    }
}
