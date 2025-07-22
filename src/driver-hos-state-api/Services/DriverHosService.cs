using driver_hos_state_api.Models;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace driver_hos_state_api.Services
{
    public class DriverHosService : IDriverHosService
    {
        private readonly IConfiguration _configuration;

        public DriverHosService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DriverHosStateResponse> GetDriverHosStateDataAsync(string driverCompany, string driverNumber, DateTime startDate, DateTime endDate)
        {
            var response = new DriverHosStateResponse
            {
                DriverCompany = driverCompany,
                DriverNumber = driverNumber,
                StartDate = startDate,
                EndDate = endDate,
                Records = new List<DriverHosRecord>()
            };

            var connectionString = _configuration.GetConnectionString("MobileComm");

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // TODO: Replace with actual stored procedure name and parameter names
            var results = await connection.QueryAsync<DriverHosRecord>(
                sql: "TBD_StoredProcedureName",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    DriverCompany = driverCompany,
                    DriverNumber = driverNumber,
                    StartDate = startDate,
                    EndDate = endDate
                });

            response.Records = results.ToList();
            return response;
        }
    }
}