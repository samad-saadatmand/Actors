using Actors.Application.Common.Exceptions;
using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Commands.AddActorMovies;
using Actors.Domain.Constants;
using Actors.Domain.Entities;
using MediatR;
using MockQueryable.Moq;
using Moq;

namespace Actors.UnitTests.Application.Actors;
public class AddActorMoviesCommandHandlerTest
{
    [Fact]
    public async Task AddMovie_ShouldThrowNotFoundException()
    {
        // Arrange
        var command = new AddActorMoviesCommand(Guid.NewGuid(), "Movie1", new DateTime(1999, 3, 31));

        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>().AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var handler = new AddActorMoviesCommandHandler(mockContext.Object);
        var result = () => handler.Handle(command, default);

        //Assert
        var exception = await Assert.ThrowsAsync<ActorsException>(result);
        Assert.Equal(ActorsMessages.NotFound, exception.Code);
    }

    [Fact]
    public async Task AddMovie_ShouldAddMovieToActor()
    {
        // Arrange
        var command = new AddActorMoviesCommand(Guid.NewGuid(), "Movie1", new DateTime(1999, 3, 31));
        var actor = new Actor { Id = command.ActorId, FirstName = "Actor1", LastName = "Test", Movies = new List<Movie>() };

        var mockContext = new Mock<IActorsContext>();
        var dbSet = new List<Actor>() { actor }.AsQueryable().BuildMockDbSet();
        mockContext.Setup(c => c.Actors).Returns(dbSet.Object);

        // Act
        var handler = new AddActorMoviesCommandHandler(mockContext.Object);
        var result = await handler.Handle(command, default);

        // Assert
        Assert.Equal(Unit.Value, result);
        Assert.Single(actor.Movies);
        Assert.Equal(command.MovieName, actor.Movies.First().Name);
        Assert.Equal(command.MovieReleaseDate, actor.Movies.First().ReleaseDate);
        mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

}
