using System.ComponentModel.DataAnnotations;

namespace Actors.Domain.Entities;

public class Actor
{

    public Guid Id { get; set; }

    [StringLength(256)]
    public required string FirstName { get; set; }

    [StringLength(256)]
    public required string LastName { get; set; }
    public int Age { get; set; }

    public ICollection<Movie> Movies { get; set; }


}
