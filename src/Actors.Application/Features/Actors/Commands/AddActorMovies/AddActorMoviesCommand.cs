using MediatR;

namespace Actors.Application.Features.Actors.Commands.AddActorMovies;
public record AddActorMoviesCommand(Guid ActorId, string MovieName, DateTime MovieReleaseDate) : IRequest<Unit>;

