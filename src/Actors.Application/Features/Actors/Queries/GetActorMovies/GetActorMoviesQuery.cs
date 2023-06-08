using Actors.Application.Features.Actors.Models;
using MediatR;

namespace Actors.Application.Features.Actors.Queries.GetActorMovies;
public record GetActorMoviesQuery(Guid Id) : IRequest<List<MovieVm>>;
