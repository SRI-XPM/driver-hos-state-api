using driver_hos_state_api.Models;

namespace driver_hos_state_api.Services
{
    public interface IDriverHosService
    {
        Task<DriverHosStateResponse> GetDriverHosStateDataAsync(string driverCompany, string driverNumber, DateTime startDate, DateTime endDate);
    }
}
