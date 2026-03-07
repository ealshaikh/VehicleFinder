using Microsoft.AspNetCore.Mvc;
using VehicleDataAPI.Clients;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleApiClient _vehicleClient;

        public VehiclesController(IVehicleApiClient vehicleClient)
        {
            _vehicleClient = vehicleClient;
        }

        [HttpGet("makes")]
        public async Task<IActionResult> GetMakes([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        {
            var allMakes = await _vehicleClient.GetMakes(); 

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
