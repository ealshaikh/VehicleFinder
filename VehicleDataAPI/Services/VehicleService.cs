using VehicleDataAPI.Models.ResponseDtos;
using VehicleDataAPI.Clients;
namespace VehicleDataAPI.Services
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleApiClient _vehicleApiClient;
        public VehicleService(IVehicleApiClient vehicleApiClient)
        {
            _vehicleApiClient = vehicleApiClient;
        }
        public async Task<MakesResponseDTO> GetMakesAsync(int page, int pageSize)
        {
            try
            {
                var allMakes = await _vehicleApiClient.GetMakes();

                var paged = allMakes.Makes
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new MakesResponseDTO
                {
                    Count = allMakes.Count,
                    Message = allMakes.Message,
                    Makes = paged
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
        }
    }
}
