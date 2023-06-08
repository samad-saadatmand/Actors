using Actors.Application.Common.Interfaces;
using Actors.Domain.Entities;
using MediatR;

namespace Actors.Application.Features.Actors.Commands.AddActor;
public class AddActorCommandHandler : IRequestHandler<AddActorCommand, Guid>
{
    private readonly IActorsContext _context;

    public AddActorCommandHandler(IActorsContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(AddActorCommand request, CancellationToken cancellationToken)
    {
        var actor = new Actor()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age
        };
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();

        return actor.Id;
    }
}