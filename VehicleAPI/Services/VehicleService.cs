using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using VehicleAPI.Configurations;
using VehicleAPI.Models;

namespace VehicleAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;


        public VehicleService(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }
        public async Task<ApiResponse<List<VehicleMake>>> GetAllMakesAsync()
        {
            var response = await GetApiResponse<List<VehicleMake>>(_apiUrls.VehicleMakesUrl);
            return response;
        }

        public async Task<ApiResponse<List<VehicleType>>> GetVehicleTypesForMakeIdAsync(int makeId)
        {
            var url = _apiUrls.VehicleTypesUrl.Replace("{makeId}", makeId.ToString());
            var response = await GetApiResponse<List<VehicleType>>(url);
            return response;
        }

        public async Task<ApiResponse<List<Vehicle>>> GetModelsForMakeIdYearAsync(int makeId, int modelyear)
        {
            var url = _apiUrls.ModelsUrl.Replace("{makeId}", makeId.ToString()).Replace("{year}", modelyear.ToString());
            var response = await GetApiResponse<List<Vehicle>>(url);
            return response;
        }

        private async Task<ApiResponse<T>> GetApiResponse<T>(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ApiResponse<T>>(response);
        }
    }
}
