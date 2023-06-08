﻿using Actors.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Actors.Application.Common.Interfaces;

public interface IActorsContext
{
    DbSet<Actor> Actors { get; set; }
    DbSet<Movie> Movies { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

}
