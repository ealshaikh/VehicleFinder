using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Services
{
    public interface IVehicleService
    {
        Task<MakesResponseDTO> GetMakesAsync(int page, int pageSize, CancellationToken cancellationToken = default);
        Task<VehicleTypeResponseDto> GetVehicleTypesAsync(int makeId, int page, int pageSize, CancellationToken cancellationToken = default);
        Task<ModelResponseDto> GetModelsAsync(int makeId, int modelYear, int page, int pageSize, CancellationToken cancellationToken = default);
    }
}
