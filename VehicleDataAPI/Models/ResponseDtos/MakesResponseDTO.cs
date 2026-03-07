using VehicleDataAPI.Models.Dtos;

namespace VehicleDataAPI.Models.ResponseDtos
{
    public class MakesResponseDTO
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<MakeDTO> Makes { get; set; }
    }
}
