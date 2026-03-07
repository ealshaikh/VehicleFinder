using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Clients
{
    public interface IVehicleApiClient
    {
        Task<MakesResponseDTO> GetMakes(CancellationToken cancellationToken);

        Task<VehicleTypeResponseDto> GetVehicleTypes(int makeId, CancellationToken cancellationToken);

        Task<ModelResponseDto> GetModelsForMake(int makeId, int yearId, CancellationToken cancellationToken);

    }
}
