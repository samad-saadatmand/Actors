using System.ComponentModel.DataAnnotations;

namespace Actors.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }

    [StringLength(256)]
    public required string Name { get; set; }

    public DateTime ReleaseDate { get; set; }

    public ICollection<Actor> Actors { get; set; }


}
