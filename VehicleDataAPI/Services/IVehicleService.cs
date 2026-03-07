using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Services
{
    public interface IVehicleService
    {
        Task<MakesResponseDTO> GetMakesAsync(int page, int pageSize);

    }
}
