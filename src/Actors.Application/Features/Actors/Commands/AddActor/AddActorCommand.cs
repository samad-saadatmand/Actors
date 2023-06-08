using MediatR;

namespace Actors.Application.Features.Actors.Commands.AddActor;
public record AddActorCommand(string FirstName, string LastName, int Age) : IRequest<Guid>;