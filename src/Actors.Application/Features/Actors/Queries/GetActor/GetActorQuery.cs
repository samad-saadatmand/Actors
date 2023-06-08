using Actors.Application.Features.Actors.Models;
using MediatR;

namespace Actors.Application.Features.Actors.Queries.GetActor;
public record GetActorQuery(Guid Id) : IRequest<ActorVm>;
