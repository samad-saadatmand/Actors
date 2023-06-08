using Actors.Application.Common.Interfaces;
using Actors.Application.Features.Actors.Models;
using Actors.Application.Features.Actors.Queries.GetActor;
using Actors.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Actors.Application.Features.Actors.Queries.GetActorMovies;
public class GetActorMoviesQueryHandler : IRequestHandler<GetActorMoviesQuery, List<MovieVm>>
{
    private readonly IActorsContext _context;
    private readonly IMediator _mediator;
    public GetActorMoviesQueryHandler(IActorsContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<List<MovieVm>> Handle(GetActorMoviesQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new GetActorQuery(request.Id));

        List<Movie> movies = await _context.Actors.Where(c => c.Id == request.Id)
                            .Include(c => c.Movies)
                            .AsNoTracking()
                            .SelectMany(c => c.Movies)
                            .ToListAsync(cancellationToken: cancellationToken);

        List<MovieVm> data = new();
        if (movies is { Count: > 0 })
        {
            data = movies.Select(c => new MovieVm(c.Id, c.Name, c.ReleaseDate))
                           .OrderByDescending(c => c.ReleaseDate)
                           .ToList();
        }

        return data;
    }
}
