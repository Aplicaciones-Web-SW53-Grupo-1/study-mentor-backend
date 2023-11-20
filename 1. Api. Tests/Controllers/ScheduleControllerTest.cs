using _1._API.Controllers;
using _1._API.Request;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
namespace _1.API._Tests.Controller;

public class ScheduleControllerTest
{
    [Fact]
    public void Post_ValidScheduleRequest_ReturnsOkResult()
    {
        // Arrange
        var scheduleRequest = new ScheduleRequest
        {
            Title = "Test Schedule",
            Description = "Description of the schedule",
            DateCreated = DateTime.Now,
            StudentId = 1
        };

        var scheduleDomainMock = Substitute.For<IScheduleDomain>();
        scheduleDomainMock.Create(Arg.Any<Schedule>()).Returns(true);

        var controller = new ScheduleController(null, scheduleDomainMock);

        // Act
        var result = controller.Post(scheduleRequest);

        // Assert
        Assert.IsType<OkResult>(result);
        scheduleDomainMock.Received(1).Create(Arg.Any<Schedule>());
    }

    [Fact]
    public void Post_InvalidScheduleRequest_ReturnsBadRequestResult()
    {
        // Arrange
        var scheduleDataMock = Substitute.For<IScheduleData>();
        var scheduleDomainMock = Substitute.For<IScheduleDomain>();

        var controller = new ScheduleController(scheduleDataMock, scheduleDomainMock);

        // ScheduleRequest sin Title, lo que lo hace inválido
        var scheduleRequest = new ScheduleRequest
        {
            Description = "Description of the schedule",
            DateCreated = DateTime.Now,
            StudentId = 1
            // Agrega otros campos según sea necesario
        };

        controller.ModelState.AddModelError("Title", "El campo Title es obligatorio");

        // Act
        var result = controller.Post(scheduleRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        scheduleDomainMock.DidNotReceive().Create(Arg.Any<Schedule>());
    }
}