using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleDataAPI.Clients;
using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;
namespace VehicleDataAPI.Services
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleApiClient _vehicleApiClient;
        public VehicleService(IVehicleApiClient vehicleApiClient)
        {
            _vehicleApiClient = vehicleApiClient;
        }
        public async Task<MakesResponseDTO> GetMakesAsync(int page, int pageSize, CancellationToken cancellationToken = default)
        {
            try
            {
                var allMakes = await _vehicleApiClient.GetMakes(cancellationToken);

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
        public async Task<VehicleTypeResponseDto> GetVehicleTypesAsync(int makeId, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            try
            {
                var allVehicle = await _vehicleApiClient.GetVehicleTypes(makeId, cancellationToken);

                var paged = allVehicle.VehicleTypes
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new VehicleTypeResponseDto
                {
                    Count = allVehicle.Count,
                    Message = allVehicle.Message,
                    VehicleTypes = paged
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
        }
        public async Task<ModelResponseDto> GetModelsAsync(int makeId, int modelYear, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            try
            {
                var allModels = await _vehicleApiClient.GetModelsForMake(makeId, modelYear, cancellationToken);

                var paged = allModels.Models
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new ModelResponseDto
                {
                    Count = allModels.Count,
                    Message = allModels.Message,
                    Models = paged
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
        }
    }
}
