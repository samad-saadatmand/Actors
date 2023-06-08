using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Actors.Application.Features.Actors.Queries.GetActors;
public class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, List<ActorVm>>
{
    private readonly IActorsContext _context;

    public GetActorsQueryHandler(IActorsContext context)
    {
        _context = context;
    }

    public async Task<List<ActorVm>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
     => await _context.Actors
               .AsNoTracking()
               .Select(c => new ActorVm(c.Id, c.FirstName, c.LastName, c.Age))
               .ToListAsync();
}
