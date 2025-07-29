using driver_hos_state_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driver_hos_state_api.Tests.Models
{
    public class DriverHosStateResponseTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var driverCompany = "ABC Transport";
            var driverNumber = "12345";
            var startDate = new DateTime(2025, 7, 1);
            var endDate = new DateTime(2025, 7, 7);

            // Act
            var response = new DriverHosStateResponse
            {
                DriverCompany = driverCompany,
                DriverNumber = driverNumber,
                StartDate = startDate,
                EndDate = endDate
            };

            // Assert
            Assert.Equal(driverCompany, response.DriverCompany);
            Assert.Equal(driverNumber, response.DriverNumber);
            Assert.Equal(startDate, response.StartDate);
            Assert.Equal(endDate, response.EndDate);
        }

        [Fact]
        public void Records_Property_ShouldInitializeAsEmptyList()
        {
            // Act
            var response = new DriverHosStateResponse();

            // Assert
            Assert.NotNull(response.Records);
            Assert.Empty(response.Records);
        }

        [Fact]
        public void ShouldAddDriverHosRecordToRecordsList()
        {
            // Arrange
            var record = new DriverHosRecord
            {
                State = "California",
                OnDutyHours = 8,
                DrivingHours = 5
            };
            var response = new DriverHosStateResponse();

            // Act
            response.Records.Add(record);

            // Assert
            Assert.Contains(record, response.Records);
            Assert.Single(response.Records);
        }

        [Fact]
        public void StartDate_ShouldBeGreaterThanEndDate_WhenInvalid()
        {
            // Arrange
            var response = new DriverHosStateResponse
            {
                StartDate = new DateTime(2025, 7, 10),
                EndDate = new DateTime(2025, 7, 5)
            };

            // Act & Assert
            Assert.True(response.StartDate > response.EndDate);
        }

        [Fact]
        public void ShouldHaveValidDriverCompanyAndNumber()
        {
            // Arrange
            var response = new DriverHosStateResponse
            {
                DriverCompany = "XYZ Logistics",
                DriverNumber = "98765"
            };

            // Act & Assert
            Assert.Equal("XYZ Logistics", response.DriverCompany);
            Assert.Equal("98765", response.DriverNumber);
        }
    }
}
