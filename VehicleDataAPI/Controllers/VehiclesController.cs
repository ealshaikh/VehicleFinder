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
        public async Task<IActionResult> GetMakes([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        {
            var allMakes = await _vehicleService.GetMakesAsync(); 

            var paged = allMakes.Makes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new MakesResponseDTO
            {
                Count = allMakes.Count,
                Message = allMakes.Message,
                Makes = paged
            });
        }

    }
}
