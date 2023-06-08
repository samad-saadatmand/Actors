using Actors.Application.Common.Exceptions;
using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using Actors.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Actors.Application.Features.Actors.Queries.GetActor;
public class GetActorQueryHandler : IRequestHandler<GetActorQuery, ActorVm>
{
    private readonly IActorsContext _context;

    public GetActorQueryHandler(IActorsContext context)
    {
        _context = context;
    }

    public async Task<ActorVm> Handle(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await _context.Actors.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (actor is null)
            throw new ActorsException(ActorsMessages.NotFound,
                ActorsMessages.NotFound
               , System.Net.HttpStatusCode.NotFound);


        return new ActorVm(actor.Id, actor.FirstName, actor.LastName, actor.Age);
    }
}
