using VehicleDataAPI.Models.Dtos;

namespace VehicleDataAPI.Models.ResponseDtos
{
    public class ModelResponseDto
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<ModelDto> Models { get; set; }
    }
}
