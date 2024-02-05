using Pizza_Cabin_Inc.Entities;
using SchedulerService.Services;

namespace UnitTesting.SchedulerServiceTests
{
    public class PrinterTests
    {
        [Fact]
        public void PrintSlotReport_WhenStandupQuorumIsMet_ShouldPrintReport()
        {
            // Arrange
            int teamMembers = 10;
            int absence = 0;
            int standupQuorum = 2;
            Dictionary<string, List<Expert>> slots = new Dictionary<string, List<Expert>>
        {
            { "9:00 AM", new List<Expert> { new Expert { Id = new Guid(), Name = "John" }, new Expert { Id = new Guid(), Name = "Jane" } } },
            { "10:00 AM", new List<Expert> { new Expert { Id = new Guid(), Name = "Alice" }, new Expert { Id = new Guid(), Name = "Bob" } } }
        };

            var slotReportPrinter = new Printer();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            slotReportPrinter.PrintSlotReport(teamMembers, absence, standupQuorum, slots);
            string output = consoleOutput.ToString();

            // Assert
            Xunit.Assert.Contains("StandUp can be hold at", output);
            Xunit.Assert.Contains("9:00 AM", output);
            Xunit.Assert.Contains("10:00 AM", output);
            Xunit.Assert.Contains("John", output);
            Xunit.Assert.Contains("Jane", output);
            Xunit.Assert.Contains("Alice", output);
            Xunit.Assert.Contains("Bob", output);
        }
        [Fact]
        public void PrintSlotReport_WhenStandupQuorumIsNotMet_ShouldPrintReport()
        {
            // Arrange
            int teamMembers = 10;
            int absence = 2;
            int standupQuorum = 7;
            Dictionary<string, List<Expert>> slots = new Dictionary<string, List<Expert>>
        {
            { "9:00 AM", new List<Expert> { new Expert { Id = new Guid(), Name = "John" }, new Expert { Id = new Guid(), Name = "Jane" } } },
            { "10:00 AM", new List<Expert> { new Expert { Id = new Guid(), Name = "Alice" }, new Expert { Id = new Guid(), Name = "Bob" } } }
        };

            var slotReportPrinter = new Printer();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            slotReportPrinter.PrintSlotReport(teamMembers, absence, standupQuorum, slots);
            string output = consoleOutput.ToString();

            // Assert
            Xunit.Assert.Contains("can not find an appropriate time for this Standup Quorum", output);

        }

    }
}
