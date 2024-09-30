using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Services;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("makes")]
        public async Task<ActionResult<List<VehicleMake>>> GetAllMakes()
        {
            var makes = await _vehicleService.GetAllMakesAsync();
            return Ok(makes);
        }

        [HttpGet("vehicle-types/{makeId}")]
        public async Task<ActionResult<List<VehicleType>>> GetVehicleTypes(int makeId)
        {
            var types = await _vehicleService.GetVehicleTypesForMakeIdAsync(makeId);
            return Ok(types);
        }

        [HttpGet("models/{makeId}/{year}")]
        public async Task<ActionResult<List<Vehicle>>> GetModels(int makeId, int year)
        {
            var models = await _vehicleService.GetModelsForMakeIdYearAsync(makeId, year);
            return Ok(models);
        }
    }
}
