using Actors.Application.Features.Actors.Models;
using MediatR;

namespace Actors.Application.Features.Actors.Queries.GetActors;
public record GetActorsQuery : IRequest<List<ActorVm>>;
