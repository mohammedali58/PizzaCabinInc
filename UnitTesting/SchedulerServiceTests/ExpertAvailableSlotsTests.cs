using Pizza_Cabin_Inc.Assets;
using SchedulerService.Services;

namespace UnitTesting.SchedulerServiceTests
{
    public class ExpertAvailableSlotsTests
    {

        [Fact]
        public void FindExpertSlots_WhenDurationIsMultipleSlots_ShouldReturnValidSlots()
        {
            // Arrange
            DateTime startTime = new DateTime(2024, 1, 1, 9, 0, 0); // January 1, 2024, 9:00 AM

            int duration = 60; // 60 minutes

            var slotFinder = new ExpertAvailableSlots();

            // Act
            List<string> availableSlots = slotFinder.FindExpertSlots(startTime, duration);

            // Assert
            // Verify that the available slots are not equal null 
           Assert.NotNull(availableSlots);
        }

        [Fact]
        public void FindExpertSlots_WhenDurationIsMultipleOfStandupDuration_ShouldReturnValidSlots()
        {
            // Arrange
            DateTime startTime = new DateTime(2024, 1, 1, 9, 0, 0); // January 1, 2024, 9:00 AM
            int duration = 75; // 75 minutes

            var slotFinder = new ExpertAvailableSlots();

            // Act
            List<string> availableSlots = slotFinder.FindExpertSlots(startTime, duration);

            // Assert
            // Verify that the available slots are correctly calculated for the given duration
            Xunit.Assert.Equal(duration / WorkDescriptionAssets.StandupDuration -1  , availableSlots.Count);
        }

       
    }
}
