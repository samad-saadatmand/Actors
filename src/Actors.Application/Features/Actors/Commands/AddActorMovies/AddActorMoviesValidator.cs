using Actors.Domain.Constants;
using FluentValidation;

namespace Actors.Application.Features.Actors.Commands.AddActorMovies;
public class AddActorMoviesValidator : AbstractValidator<AddActorMoviesCommand>
{
    public AddActorMoviesValidator()
    {
        RuleFor(p => p.ActorId)
           .NotNull()
           .NotEmpty()
           .WithMessage(ActorsMessages.IsRequired);

        RuleFor(p => p.MovieName)
          .NotNull()
           .NotEmpty()
           .WithMessage(ActorsMessages.IsRequired);

        RuleFor(p => p.MovieReleaseDate)
          .NotNull()
          .NotEmpty()
          .WithMessage(ActorsMessages.IsRequired);


    }
}
