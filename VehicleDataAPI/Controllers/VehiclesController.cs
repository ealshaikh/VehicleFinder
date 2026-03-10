using Microsoft.AspNetCore.Mvc;
using System.Threading;
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

        #region Helper Methods
        private IActionResult ValidatePagination(int page, int pageSize)
        {
            if (page <= 0) return BadRequest("page must be > 0");
            if (pageSize <= 0) return BadRequest("pageSize must be > 0");
            return null;
        }
        #endregion
         [HttpGet("makes")]
         [ProducesResponseType(typeof(MakesResponseDTO), StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         public async Task<IActionResult> GetMakes(
         [FromQuery] string? search = null,
         [FromQuery] int page = 1,
         [FromQuery] int pageSize = 100,
         CancellationToken cancellationToken = default)
         {
               var validationResult = ValidatePagination(page, pageSize);
               if (validationResult != null)
                   return validationResult;

               var result = await _vehicleService.GetMakesAsync(search, page, pageSize, cancellationToken);
               return Ok(result);
          }

        [HttpGet("types")]
        [ProducesResponseType(typeof(VehicleTypeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTypes([FromQuery] int makeId, [FromQuery] int page = 1, [FromQuery] int pageSize = 100, CancellationToken cancellationToken = default)
        {
            var validationResult = ValidatePagination(page, pageSize);
            if (validationResult != null)
                return validationResult;

            if (makeId <= 0)
                return BadRequest("makeId must be greater than 0");

            var result = await _vehicleService.GetVehicleTypesAsync(makeId, page, pageSize, cancellationToken);
            return Ok(result);
        }

        [HttpGet("models")]
        [ProducesResponseType(typeof(ModelResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModels([FromQuery] int makeId, [FromQuery] int modelYear, [FromQuery] int page = 1, [FromQuery] int pageSize = 100, CancellationToken cancellationToken = default)
        {
            var validationResult = ValidatePagination(page, pageSize);
            if (validationResult != null)
                return validationResult;

            if (makeId <= 0)
                return BadRequest("makeId must be greater than 0");

            if (modelYear <= 0)
                return BadRequest("modelYear must be greater than 0");

            var result = await _vehicleService.GetModelsAsync(makeId, modelYear, page, pageSize, cancellationToken);
            return Ok(result);
        }
    }

}
