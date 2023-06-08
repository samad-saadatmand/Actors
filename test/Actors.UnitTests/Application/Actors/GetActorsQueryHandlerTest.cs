using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using Actors.Application.Features.Actors.Queries.GetActors;
using Actors.Domain.Entities;
using MockQueryable.Moq;
using Moq;

namespace Actors.UnitTests.Application.Actors;
public class GetActorsQueryHandlerTest
{
    [Fact]
    public async Task GetActors_ShouldReturnListOfActorVm()
    {
        // Arrange
        var query = new GetActorsQuery();

        var actors = new List<Actor>
        {
            new Actor { Id = Guid.NewGuid(), FirstName = "Actor1", LastName = "Test1", Age = 30 },
            new Actor { Id = Guid.NewGuid(), FirstName = "Actor2", LastName = "Test2", Age = 25 },
            new Actor { Id = Guid.NewGuid(), FirstName = "Actor3", LastName = "Test3", Age = 40 }
        };

        var mockContext = new Mock<IActorsContext>();
        var dbSet = actors.AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var handler = new GetActorsQueryHandler(mockContext.Object);
        var result = await handler.Handle(query, default); ;

        // Assert
        Assert.Equal(actors.Count, result.Count);
        for (int i = 0; i < actors.Count; i++)
        {
            Assert.IsType<ActorVm>(result[i]);
            Assert.Equal(actors[i].Id, result[i].Id);
            Assert.Equal(actors[i].FirstName, result[i].FirstName);
            Assert.Equal(actors[i].LastName, result[i].LastName);
            Assert.Equal(actors[i].Age, result[i].Age);
        }
    }

}
