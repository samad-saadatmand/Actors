using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Commands.AddActor;
using Actors.Domain.Entities;
using MockQueryable.Moq;
using Moq;

namespace Actors.UnitTests.Application.Actors;
public class AddActorCommandHandlerTest
{
    [Fact]
    public async Task AddActor_ReturnsActorId()
    {
        // Arrange      
        var command = new AddActorCommand("John", "Doe", 30);
        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>().AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var handler = new AddActorCommandHandler(mockContext.Object);
        var result = await handler.Handle(command, default);

        // Assert
        Assert.IsType<Guid>(result);
        mockContext.Verify(c => c.Actors.Add(It.IsAny<Actor>()), Times.Once);
        mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}
