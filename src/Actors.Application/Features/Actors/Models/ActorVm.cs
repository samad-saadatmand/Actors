namespace Actors.Application.Features.Actors.Models;
public class ActorVm
{
    public ActorVm(Guid id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
