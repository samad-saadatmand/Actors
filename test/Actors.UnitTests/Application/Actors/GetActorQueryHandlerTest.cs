using Actors.Application.Common.Exceptions;
using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using Actors.Application.Features.Actors.Queries.GetActor;
using Actors.Domain.Constants;
using Actors.Domain.Entities;
using MockQueryable.Moq;
using Moq;

namespace Actors.UnitTests.Application.Actors;
public class GetActorQueryHandlerTest
{
    [Fact]
    public async Task GetActor_ShouldReturnActorVm()
    {
        // Arrange
        var query = new GetActorQuery(Guid.NewGuid());
        var actor = new Actor { Id = query.Id, FirstName = "Actor", LastName = "Test", Age = 30 };

        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>() { actor }.AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var hadler = new GetActorQueryHandler(mockContext.Object);
        var result = await hadler.Handle(query, default);

        // Assert
        Assert.IsType<ActorVm>(result);
        Assert.Equal(actor.Id, result.Id);
        Assert.Equal(actor.FirstName, result.FirstName);
        Assert.Equal(actor.LastName, result.LastName);
        Assert.Equal(actor.Age, result.Age);
    }

    [Fact]
    public async Task GetActor_ShouldThrowNotFoundException()
    {
        // Arrange
        var query = new GetActorQuery(Guid.NewGuid());

        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>().AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var handler = new GetActorQueryHandler(mockContext.Object);
        var result = () => handler.Handle(query, default);

        //Assert
        var exception = await Assert.ThrowsAsync<ActorsException>(result);
        Assert.Equal(ActorsMessages.NotFound, exception.Code);
    }

}
