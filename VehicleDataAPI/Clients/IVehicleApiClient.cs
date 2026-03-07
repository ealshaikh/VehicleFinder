using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Clients
{
    public interface IVehicleApiClient
    {
        Task<MakesResponseDTO> GetMakes();

        Task<VehicleTypeResponseDto> GetVehicleTypes(int makeId);

        Task<ModelResponseDto> GetModelsForMake(int makeId, int yearId);

    }
}
