using Moq;
using Xunit;
using driver_hos_state_api.Models;
using driver_hos_state_api.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace driver_hos_state_api.Tests.Services
{
    public class DriverHosServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IDbConnection> _mockDapperConnection;
        private readonly DriverHosService _service;

        public DriverHosServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockDapperConnection = new Mock<IDbConnection>();

            // Mock the configuration to return a mock connection string
            _mockConfiguration.Setup(c => c.GetConnectionString("MobileComm"))
                .Returns("FakeConnectionString");

            // Instantiate the service with mocked dependencies
            _service = new DriverHosService(_mockConfiguration.Object);
        }

      
    }
}
