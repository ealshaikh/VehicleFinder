using VehicleDataAPI.Models.Dtos;

namespace VehicleDataAPI.Models.ResponseDtos
{
    public class VehicleTypeResponseDto
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<VehicleTypeDto> VehicleTypes { get; set; }
    }
}
