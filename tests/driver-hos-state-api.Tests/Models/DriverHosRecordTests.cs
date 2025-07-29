using driver_hos_state_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driver_hos_state_api.Tests.Models
{
    public class DriverHosRecordTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var state = "California";
            var onDutyHours = 8;
            var drivingHours = 5;

            // Act
            var record = new DriverHosRecord
            {
                State = state,
                OnDutyHours = onDutyHours,
                DrivingHours = drivingHours
            };

            // Assert
            Assert.Equal(state, record.State);
            Assert.Equal(onDutyHours, record.OnDutyHours);
            Assert.Equal(drivingHours, record.DrivingHours);
        }

        [Fact]
        public void State_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var record = new DriverHosRecord();
            var state = "New York";

            // Act
            record.State = state;

            // Assert
            Assert.Equal(state, record.State);
        }

        [Fact]
        public void OnDutyHours_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var record = new DriverHosRecord();
            var onDutyHours = 10;

            // Act
            record.OnDutyHours = onDutyHours;

            // Assert
            Assert.Equal(onDutyHours, record.OnDutyHours);
        }

        [Fact]
        public void DrivingHours_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var record = new DriverHosRecord();
            var drivingHours = 6;

            // Act
            record.DrivingHours = drivingHours;

            // Assert
            Assert.Equal(drivingHours, record.DrivingHours);
        }
    }
}
