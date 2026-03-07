using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Clients
{
    public interface IVehicleApiClient
    {
        Task<MakesResponseDTO> GetMakes();

        Task<List<VehicleTypeDto>> GetVehicleTypes(int makeId);

        Task<List<ModelDto>> GetModelsForMake(int makeId, int yearId);

    }
}
