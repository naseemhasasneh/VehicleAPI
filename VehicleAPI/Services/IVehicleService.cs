using VehicleAPI.Models;

namespace VehicleAPI.Services
{
    public interface IVehicleService
    {
        Task<ApiResponse<List<VehicleMake>>> GetAllMakesAsync();
        Task<ApiResponse<List<VehicleType>>> GetVehicleTypesForMakeIdAsync(int makeID);
        Task<ApiResponse<List<Vehicle>>> GetModelsForMakeIdYearAsync(int makeId, int modelyear);
    }
}
