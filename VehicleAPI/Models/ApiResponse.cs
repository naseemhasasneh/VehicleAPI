namespace VehicleAPI.Models
{
    public class ApiResponse<T>
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public T Results { get; set; }
    }
}
