using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using Actors.Application.Features.Actors.Queries.GetActor;
using Actors.Application.Features.Actors.Queries.GetActorMovies;
using Actors.Domain.Entities;
using MediatR;
using MockQueryable.Moq;
using Moq;

namespace Actors.UnitTests.Application.Actors;
public class GetActorMoviesQueryHandlerTest
{
    [Fact]
    public async Task GetMoviesByActorId_ShouldReturnListOfMovieVm()
    {
        // Arrange
        var query = new GetActorMoviesQuery(Guid.NewGuid());

        var actor = new Actor
        {
            Id = query.Id,
            FirstName = "Actor",
            LastName = "Test",
            Age = 30,
            Movies = new List<Movie>
            {
                new Movie { Id = Guid.NewGuid(), Name = "Movie1", ReleaseDate = new DateTime(1999, 3, 31) },
                new Movie { Id = Guid.NewGuid(), Name = "Movie2", ReleaseDate = new DateTime(2014, 10, 24) },
                new Movie { Id = Guid.NewGuid(), Name = "Movie3", ReleaseDate = new DateTime(1994, 6, 10) }
            }
        };
        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>() { actor }.AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(c => c.Send(It.IsAny<GetActorQuery>(), default))
            .ReturnsAsync(new ActorVm(actor.Id, actor.FirstName, actor.LastName, actor.Age));

        // Act
        var hadler = new GetActorMoviesQueryHandler(mockContext.Object, mockMediator.Object);
        var result = await hadler.Handle(query, default);

        // Assert
        Assert.Equal(actor.Movies.Count, result.Count);
    }

}
