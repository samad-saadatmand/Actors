using Actors.Application.Common.Exceptions;
using Actors.Application.Common.Interfaces;
using Actors.Domain.Constants;
using Actors.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Actors.Application.Features.Actors.Commands.AddActorMovies;
public class AddActorMoviesCommandHandler : IRequestHandler<AddActorMoviesCommand, Unit>
{
    private readonly IActorsContext _context;

    public AddActorMoviesCommandHandler(IActorsContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddActorMoviesCommand request, CancellationToken cancellationToken)
    {
        var actor = await _context.Actors
                          .Include(c => c.Movies)
                          .FirstOrDefaultAsync(c => c.Id == request.ActorId);

        if (actor is null)
            throw new ActorsException(ActorsMessages.NotFound,
                ActorsMessages.NotFound
               , System.Net.HttpStatusCode.NotFound);

        actor.Movies ??= new List<Movie>();

        actor.Movies.Add(new Movie { Name = request.MovieName, ReleaseDate = request.MovieReleaseDate });

        await _context.SaveChangesAsync();

        return Unit.Value;
    }

}