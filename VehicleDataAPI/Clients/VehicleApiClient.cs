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

        public Task<List<ModelDto>> GetModelsForMake(int makeId, int yearId)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleTypeDto>> GetVehicleTypes(int makeId)
        {
            throw new NotImplementedException();
        }
    }
}
