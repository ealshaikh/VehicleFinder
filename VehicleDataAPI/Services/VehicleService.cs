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
        public async Task<MakesResponseDTO> GetMakesAsync()
        {
            return await _vehicleApiClient.GetMakes();
        }
    }
}
