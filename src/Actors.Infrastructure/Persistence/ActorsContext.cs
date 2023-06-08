using Actors.Application.Common.Interfaces;
using Actors.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Actors.Infrastructure.Persistence;
internal class ActorsContext : DbContext, IActorsContext
{
    public ActorsContext(DbContextOptions<ActorsContext> options) : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
