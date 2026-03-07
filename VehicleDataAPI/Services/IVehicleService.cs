using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Services
{
    public interface IVehicleService
    {
        Task<MakesResponseDTO> GetMakesAsync(int page, int pageSize);
        Task<VehicleTypeResponseDto> GetVehicleTypesAsync(int makeId, int page, int pageSize);

    }
}
