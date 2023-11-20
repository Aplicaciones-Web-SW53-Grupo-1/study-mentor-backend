using _3._Data;
using _3._Data.Model;
using NSubstitute;
namespace _2._Domain._Tests;

public class ScheduleDomainTest
{
    [Fact]
    public void Create_NewSchedule_ReturnsTrue()
    {
        // Arrange
        var schedule = new Schedule
        {
            Title = "Test Schedule",
            Description = "Description of the schedule",
            StudentId = 1,
        };

        var scheduleDataMock = Substitute.For<IScheduleData>();
        scheduleDataMock.GetByTitle(schedule.Title).Returns((Schedule)null);
        scheduleDataMock.Create(schedule).Returns(true);

        var scheduleDomain = new ScheduleDomain(scheduleDataMock);

        // Act
        var result = scheduleDomain.Create(schedule);

        // Assert
        Assert.True(result);
        scheduleDataMock.Received(1).GetByTitle(schedule.Title);
        scheduleDataMock.Received(1).Create(schedule);
    }

    [Fact]
    public void Create_ExistingSchedule_ReturnsFalse()
    {
        // Arrange
        var schedule = new Schedule
        {
            Title = "Test Schedule",
            Description = "Description of the schedule",
            StudentId = 1,
        };

        var existingSchedule = new Schedule
        {
            Title = "Test Schedule",
            Description = "Description of the existing schedule",
            StudentId = 1,
        };

        var scheduleDataMock = Substitute.For<IScheduleData>();
        scheduleDataMock.GetByTitle(schedule.Title).Returns(existingSchedule);

        var scheduleDomain = new ScheduleDomain(scheduleDataMock);

        // Act
        var result = scheduleDomain.Create(schedule);

        // Assert
        Assert.False(result);
        scheduleDataMock.Received(1).GetByTitle(schedule.Title);
        scheduleDataMock.DidNotReceive().Create(Arg.Any<Schedule>());
    }
    
}