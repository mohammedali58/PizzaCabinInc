using SchedulerService.Services;

namespace UnitTesting.SchedulerServiceTests
{
    public class InputManagerTests
    {
        [Fact]
        public void GetstandupMembersCount_WhenValidNumberEntered_ShouldReturnNumber()
        {
            // Arrange
            int maximumAllowedNumber = 10;
            int expectedCount = 5;

            var consoleInput = new StringReader("5");
            Console.SetIn(consoleInput);

            var standupManager = new InputManager();

            // Act
            int result = standupManager.GetstandupMembersCount(maximumAllowedNumber);

            // Assert
            Xunit.Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetstandupMembersCount_WhenInvalidNumberEnteredThenValidNumber_ShouldReturnValidNumber()
        {
            // Arrange
            int maximumAllowedNumber = 10;
            int expectedCount = 7;

            var consoleInput = new StringReader("invalid\n7");
            Console.SetIn(consoleInput);

            var standupManager = new InputManager();

            // Act
            int result = standupManager.GetstandupMembersCount(maximumAllowedNumber);

            // Assert
            Xunit.Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetstandupMembersCount_WhenNumberOutOfRangeEnteredThenValidNumber_ShouldReturnValidNumber()
        {
            // Arrange
            int maximumAllowedNumber = 10;
            int expectedCount = 3;

            var consoleInput = new StringReader("15\n3");
            Console.SetIn(consoleInput);

            var standupManager = new InputManager();

            // Act
            int result = standupManager.GetstandupMembersCount(maximumAllowedNumber);

            // Assert
            Xunit.Assert.Equal(expectedCount, result);
        }
    }

}

