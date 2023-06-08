namespace Actors.Application.Features.Actors.Models;
public class MovieVm
{
    public MovieVm(Guid id, string name, DateTime releaseDate)
    {
        Id = id;
        Name = name;
        ReleaseDate = releaseDate;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime ReleaseDate { get; set; }
}
