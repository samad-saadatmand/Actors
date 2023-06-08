using Actors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Actors.Infrastructure.Persistence;

public static class ActorsContextSeed
{
    public static async Task SeedDatabase(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ActorsContext>();
            if (context.Database.IsRelational())
            {
                context.Database.Migrate();
            }

            await SeedActorsAsync(context);
        }
    }

    static async Task SeedActorsAsync(ActorsContext context)
    {
        List<Actor> actors = GetListOfActors();
        context.AddRange(actors);
        await context.SaveChangesAsync();
    }

    public static List<Actor> GetListOfActors()
    {
        List<Actor> actors = new List<Actor>()
        {
            new Actor()
            {
                FirstName = "Kate",
                LastName = "Winslet",
                Age = 45,
                Movies = new List<Movie>()
                {
                    new Movie(){Name ="Titanic",  ReleaseDate = new DateTime(1997, 12, 19)},
                    new Movie(){Name="The Reader",ReleaseDate =  new DateTime(2008, 12, 10) },
                    new Movie() { Name = "Revolutionary Road", ReleaseDate =  new  DateTime(2008, 12, 15) },
                    new Movie(){Name="Sense and Sensibility", ReleaseDate =   new DateTime(1995, 12, 13) },
                    new Movie(){Name="Eternal Sunshine of the Spotless Mind",  ReleaseDate =  new DateTime(2004, 3, 19) }
                }
            },
            new Actor()
            {
                FirstName = "Tom",
                LastName = "Hanks",
                Age = 65,
                Movies = new List<Movie>()
                {
                    new Movie(){ Name ="Forrest Gump", ReleaseDate = new  DateTime(1994, 7, 6)},
                    new Movie(){ Name ="Cast Away", ReleaseDate =  new DateTime(2000, 12, 7)},
                    new Movie(){ Name ="Saving Private Ryan", ReleaseDate =  new DateTime(1998, 7, 24)},
                    new Movie(){ Name ="The Green Mile", ReleaseDate =  new DateTime(1999, 12, 10)},
                    new Movie(){ Name ="Apollo 13", ReleaseDate =  new DateTime(1995, 6, 30) }
                }
            },
            new Actor()
            {
                FirstName = "Meryl",
                LastName = "Streep",
                Age = 72,
                Movies = new List<Movie>()
                {
                    new Movie(){Name="The Devil Wears Prada", ReleaseDate = new DateTime(2006, 6, 30)},
                    new Movie(){Name="Doubt", ReleaseDate = new DateTime(2008, 12, 25)},
                    new Movie(){Name="The Iron Lady", ReleaseDate = new DateTime(2011, 12, 30)},
                    new Movie(){Name="Sophie's Choice", ReleaseDate = new DateTime(1982, 12, 10)},
                    new Movie(){Name="Kramer vs. Kramer", ReleaseDate = new DateTime(1979, 12, 19) }
                }
            },
            new Actor()
            {
                FirstName = "Denzel",
                LastName = "Washington",
                Age = 66,
                Movies = new List<Movie>()
                {
                    new Movie(){Name="Training Day", ReleaseDate = new DateTime(2001, 10, 5)},
                    new Movie(){Name="Glory", ReleaseDate = new DateTime(1989, 12, 15)},
                    new Movie(){Name="Malcolm X", ReleaseDate = new DateTime(1992, 11, 18)},
                    new Movie(){Name="The Hurricane", ReleaseDate = new DateTime(1999, 9, 17)},
                    new Movie(){Name="Remember the Titans", ReleaseDate = new DateTime(2000, 9, 29) }
                }
            },
            new Actor()
            {
                FirstName = "Morgan",
                LastName = "Freeman",
                Age = 84,
                Movies = new List<Movie>()
                {
                    new Movie(){Name="The Shawshank Redemption", ReleaseDate = new DateTime(1994, 9, 23)},
                    new Movie(){Name="Million Dollar Baby", ReleaseDate = new DateTime(2004, 12, 15)},
                    new Movie(){Name="Driving Miss Daisy", ReleaseDate = new DateTime(1989, 12, 15)},
                    new Movie(){Name="Bruce Almighty", ReleaseDate = new DateTime(2003, 5, 23)},
                    new Movie(){Name="Seven", ReleaseDate = new DateTime(1995, 9, 22) }
                }
            },
            new Actor()
                {
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                    Age = 47,
                    Movies = new List<Movie>()
                {
                    new Movie(){Name="The Wolf of Wall Street", ReleaseDate = new DateTime(2013, 12, 25)},
                    new Movie(){Name="The Revenant", ReleaseDate = new DateTime(2015, 12, 25)},
                    new Movie(){Name="Inception", ReleaseDate = new DateTime(2010, 7, 16)},
                    new Movie(){Name="The Departed", ReleaseDate = new DateTime(2006, 10, 6)},
                    new Movie(){Name="Titanic", ReleaseDate = new DateTime(1997, 12, 19) }
                }
            },
            new Actor()
        {
            FirstName = "Robert",
            LastName = "De Niro",
            Age = 78,
            Movies = new List<Movie>()
    {
        new Movie(){Name="The Godfather Part II", ReleaseDate = new DateTime(1974, 12, 20)},
        new Movie(){Name="Taxi Driver", ReleaseDate = new DateTime(1976, 2, 8)},
        new Movie(){Name="Goodfellas", ReleaseDate = new DateTime(1990, 9, 19)},
        new Movie(){Name="Raging Bull", ReleaseDate = new DateTime(1980, 11, 14)},
        new Movie(){Name="The Irishman", ReleaseDate = new DateTime(2019, 11, 1) }
    }
},
            new Actor()
            {
                FirstName = "Anthony",
                LastName = "Hopkins",
                Age = 84,
                Movies = new List<Movie>()
    {
                    new Movie() { Name = "The Silence of the Lambs", ReleaseDate = new DateTime(1991, 2, 14) },
                    new Movie() { Name = "The Remains of the Day", ReleaseDate = new DateTime(1993, 11, 5) },
                    new Movie() { Name = "Legends of the Fall", ReleaseDate = new DateTime(1994, 12, 23) },
                    new Movie() { Name = "Thor", ReleaseDate = new DateTime(2011, 5, 6) },
                    new Movie()
                    {
                        Name = "Meet Joe Black",
                        ReleaseDate = new DateTime(1998, 11, 13) }
    }
                },
            new Actor()
                {
                    FirstName = "Samuel",
                    LastName = "L. Jackson",
                    Age = 72,
                    Movies = new List<Movie>()
    {
        new Movie(){Name="Pulp Fiction", ReleaseDate = new DateTime(1994, 10, 14)},
        new Movie(){Name="Snakes on a Plane", ReleaseDate = new DateTime(2006, 8, 18)},
        new Movie(){Name="Django Unchained", ReleaseDate = new DateTime(2012, 12, 25)},
        new Movie(){Name="The Avengers", ReleaseDate = new DateTime(2012, 5, 4)},
        new Movie(){Name="Jackie Brown", ReleaseDate = new DateTime(1997, 12, 25) }
    }
},
            new Actor()
            {
                FirstName = "Emma",
                LastName = "Stone",
                Age = 33,
                Movies = new List<Movie>()
                {
                    new Movie(){Name="La La Land", ReleaseDate = new DateTime(2016, 12, 9)},
                    new Movie(){Name="The Help", ReleaseDate = new DateTime(2011, 8, 10)},
                    new Movie(){Name="Birdman", ReleaseDate = new DateTime(2014, 8, 27)},
                    new Movie(){Name="Zombieland", ReleaseDate = new DateTime(2009, 10, 2)},
                    new Movie(){Name="Easy A", ReleaseDate = new DateTime(2010, 9, 16) }
                }
            },
            new Actor()
{
    FirstName = "Brad",
    LastName = "Pitt",
    Age = 58,
    Movies = new List<Movie>()
    {
      new  Movie(){Name="Fight Club", ReleaseDate = new DateTime(1999, 10, 15)},
      new  Movie(){Name="Inglourious Basterds", ReleaseDate = new DateTime(2009, 8, 21)},
      new  Movie(){Name="Moneyball", ReleaseDate = new DateTime(2011, 9, 23)},
      new  Movie(){Name="The Curious Case of Benjamin Button", ReleaseDate = new DateTime(2008, 12, 25)},
      new  Movie(){Name="Once Upon a Time in Hollywood", ReleaseDate = new DateTime(2019, 7, 26) }
    }
},
            new Actor()
{
    FirstName = "Cate",
    LastName = "Blanchett",
    Age = 52,
    Movies = new List<Movie>()
    {
       new Movie(){Name="The Lord of the Rings: The Fellowship of the Ring", ReleaseDate = new DateTime(2001, 12, 10)},
       new Movie(){Name="The Aviator", ReleaseDate = new DateTime(2004, 12, 14)},
       new Movie(){Name="Blue Jasmine", ReleaseDate = new DateTime(2013, 7, 26)},
       new Movie(){Name="Carol", ReleaseDate = new DateTime(2015, 11, 20)},
       new Movie(){Name="Thor: Ragnarok", ReleaseDate = new DateTime(2017, 11, 3) }
    }
},
            new Actor()
{
    FirstName = "Matt",
    LastName = "Damon",
    Age = 51,
    Movies = new List<Movie>()
    {
       new Movie(){Name="Good Will Hunting", ReleaseDate = new DateTime(1997, 12, 5)},
       new Movie(){Name="The Bourne Identity", ReleaseDate = new DateTime(2002, 6, 14)},
       new Movie(){Name="The Martian", ReleaseDate = new DateTime(2015, 10, 2)},
       new Movie(){Name="Ocean's Eleven", ReleaseDate = new DateTime(2001, 12, 7)},
       new Movie(){Name="The Departed", ReleaseDate = new DateTime(2006, 10, 6) }
    }
},
            new Actor()
            {
                FirstName = "Natalie",
                LastName = "Portman",
                Age = 40,
                Movies = new List<Movie>()
                {
                  new  Movie(){Name="Black Swan", ReleaseDate = new DateTime(2010, 12, 3)},
                  new  Movie(){Name="V for Vendetta", ReleaseDate = new DateTime(2006, 3, 17)},
                  new  Movie(){Name="Léon: The Professional", ReleaseDate = new DateTime(1994, 11, 18)},
                  new  Movie(){Name="Jackie", ReleaseDate = new DateTime(2016, 12, 2)},
                  new  Movie(){Name="Thor", ReleaseDate = new DateTime(2011, 5, 6) }
                }
            },
            new Actor()
{
    FirstName = "Ryan",
    LastName = "Gosling",
    Age = 41,
    Movies = new List<Movie>()
    {
        new Movie(){Name ="La La Land", ReleaseDate = new DateTime(2016, 12, 9)},
        new Movie(){Name ="Drive", ReleaseDate = new DateTime(2011, 5, 20)},
        new Movie(){Name ="The Notebook", ReleaseDate = new DateTime(2004, 6, 25)},
        new Movie(){Name ="Blade Runner 2049", ReleaseDate = new DateTime(2017, 10, 6)},
        new Movie(){Name ="The Place Beyond the Pines", ReleaseDate = new DateTime(2012, 9, 7) }
    }
},
            new Actor()
{
    FirstName = "Jodie",
    LastName = "Foster",
    Age = 59,
    Movies = new List<Movie>()
    {
        new Movie(){Name ="The Silence of the Lambs", ReleaseDate = new DateTime(1991, 2, 14)},
        new Movie(){Name ="Panic Room", ReleaseDate = new DateTime(2002, 3, 29)},
        new Movie(){Name ="Taxi Driver", ReleaseDate = new DateTime(1976, 2, 8)},
        new Movie(){Name ="Contact", ReleaseDate = new DateTime(1997, 7, 11)},
        new Movie(){Name ="The Accused", ReleaseDate = new DateTime(1988, 10, 14) }
    }
},
            new Actor()
{
    FirstName = "Johnny",
    LastName = "Depp",
    Age = 58,
    Movies = new List<Movie>()
    {
        new Movie(){Name ="Pirates of the Caribbean: The Curse of the Black Pearl", ReleaseDate = new DateTime(2003, 7, 9)},
        new Movie(){Name ="Edward Scissorhands", ReleaseDate = new DateTime(1990, 12, 14)},
        new Movie(){Name ="Sweeney Todd: The Demon Barber of Fleet Street", ReleaseDate = new DateTime(2007, 12, 21)},
        new Movie(){Name ="Donnie Brasco", ReleaseDate = new DateTime(1997, 2, 28)},
        new Movie(){Name ="Fear and Loathing in Las Vegas", ReleaseDate = new DateTime(1998, 5, 22) }
    }
},
            new Actor()
{
    FirstName = "Idris",
    LastName = "Elba",
    Age = 49,
    Movies = new List<Movie>()
    {
        new Movie(){Name ="Beasts of No Nation", ReleaseDate = new DateTime(2015, 10, 16)},
        new Movie(){Name ="Mandela: Long Walk to Freedom", ReleaseDate = new DateTime(2013, 12, 25)},
        new Movie(){Name ="The Wire", ReleaseDate = new DateTime(2002, 6, 2)},
        new Movie(){Name ="Luther", ReleaseDate = new DateTime(2010, 5, 4)},
        new Movie(){Name ="Thor: Ragnarok", ReleaseDate = new DateTime(2017, 11, 3) }
    }
},
            new Actor()
{
    FirstName = "Viola",
    LastName = "Davis",
    Age = 56,
    Movies = new List<Movie>()
    {
        new Movie(){Name="Fences", ReleaseDate = new DateTime(2016, 12, 25)},
        new Movie(){Name="The Help", ReleaseDate = new DateTime(2011, 8, 10)},
        new Movie(){Name="Doubt", ReleaseDate = new DateTime(2008, 12, 25)},
        new Movie(){Name="Widows", ReleaseDate = new DateTime(2018, 11, 16)},
        new Movie(){Name="Suicide Squad", ReleaseDate = new DateTime(2016, 8, 5) }
    }
},
            new Actor()
{
    FirstName = "Mahershala",
    LastName = "Ali",
    Age = 47,
    Movies = new List<Movie>()
    {
        new Movie(){Name = "Moonlight", ReleaseDate = new DateTime(2016, 10, 21)},
        new Movie(){Name = "Green Book", ReleaseDate = new DateTime(2018, 11, 16)},
        new Movie(){Name = "House of Cards", ReleaseDate = new DateTime(2013, 2, 1)},
        new Movie(){Name = "True Detective", ReleaseDate = new DateTime(2014, 1, 12)},
        new Movie(){Name = "Luke Cage", ReleaseDate = new DateTime(2016, 9, 30) }
    }
},
        };

        return actors;
    }
}
