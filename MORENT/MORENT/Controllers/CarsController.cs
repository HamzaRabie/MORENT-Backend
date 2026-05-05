using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MORENT.Dtos.Filters;
using MORENT.Services.Interfaces;

namespace MORENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]CarsFiltersDto filters)
        {
            var res = await _carService.GetAllAsync(filters);
            if(res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
