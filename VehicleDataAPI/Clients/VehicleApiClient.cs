using System.Text.Json;
using VehicleDataAPI.Models;
using VehicleDataAPI.Models.Dtos;
using VehicleDataAPI.Models.ResponseDtos;

namespace VehicleDataAPI.Clients
{
    public class VehicleApiClient : IVehicleApiClient
    {
        private readonly HttpClient _httpClient;

        public VehicleApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MakesResponseDTO> GetMakes()
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(
                    "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");

                using var doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;

                var makesList = root.GetProperty("Results")
                    .EnumerateArray()
                    .Select(r => new MakeDTO
                    {
                        MakeId = r.GetProperty("Make_ID").GetInt32(),
                        MakeName = r.GetProperty("Make_Name").GetString()
                    })
                    .ToList();

                return new MakesResponseDTO
                {
                    Count = root.GetProperty("Count").GetInt32(),
                    Message = root.GetProperty("Message").GetString(),
                    Makes = makesList
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Invalid JSON response from external API");
            }

        }

        public async Task<ModelResponseDto> GetModelsForMake(int makeId, int yearId)
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(
                    $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{yearId}?format=json");

                var doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;

                var modelList = root.GetProperty("Results")
                    .EnumerateArray()
                    .Select(r => new ModelDto
                    {
                        Make_ID = r.GetProperty("Make_ID").GetInt32(),
                        Make_Name = r.GetProperty("Make_Name").GetString(),
                        Model_ID = r.GetProperty("Model_ID").GetInt32(),
                        Model_Name = r.GetProperty("Model_Name").GetString()
                    })
                    .ToList();

                return new ModelResponseDto
                {
                    Count = root.GetProperty("Count").GetInt32(),
                    Message = root.GetProperty("Message").GetString(),
                    Models = modelList
                };
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Invalid JSON response from external API");
            }
        }

        public async Task<VehicleTypeResponseDto> GetVehicleTypes(int makeId)
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(
                    $"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");

                using var doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;

                var vehicleList = root.GetProperty("Results")
                  .EnumerateArray()
                  .Select(r => new VehicleTypeDto
                  {
                      VehicleType_ID = r.GetProperty("VehicleTypeId").GetInt32(),
                      VehicleType_Name = r.GetProperty("VehicleTypeName").GetString()
                  })
                  .ToList();

                return new VehicleTypeResponseDto
                {
                    Count = root.GetProperty("Count").GetInt32(),
                    Message = root.GetProperty("Message").GetString(),
                    VehicleTypes = vehicleList
                };
            }

            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException("Error calling external vehicle API", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Invalid JSON response from external API");
            }

        }
    }
}
