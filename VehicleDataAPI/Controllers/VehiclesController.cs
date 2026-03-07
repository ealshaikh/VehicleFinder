using Microsoft.AspNetCore.Mvc;
using VehicleDataAPI.Clients;
using VehicleDataAPI.Models.ResponseDtos;
using VehicleDataAPI.Services;

namespace VehicleDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("makes")]
        [ProducesResponseType(typeof(MakesResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakes([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        {
            var result = await _vehicleService.GetMakesAsync(page, pageSize);
            return Ok(result);
        }


    }
}
