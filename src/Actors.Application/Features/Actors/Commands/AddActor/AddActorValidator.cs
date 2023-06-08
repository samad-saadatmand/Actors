using Actors.Domain.Constants;
using FluentValidation;

namespace Actors.Application.Features.Actors.Commands.AddActor;
public class AddActorValidator : AbstractValidator<AddActorCommand>
{
    public AddActorValidator()
    {
        RuleFor(p => p.FirstName)
           .NotNull()
           .NotEmpty()
           .WithMessage(ActorsMessages.IsRequired)
           .MaximumLength(255)
           .WithMessage(string.Format(ActorsMessages.MaxLenght, 256));

        RuleFor(p => p.LastName)
           .NotNull()
           .NotEmpty()
           .WithMessage(ActorsMessages.IsRequired)
           .MaximumLength(255)
           .WithMessage(string.Format(ActorsMessages.MaxLenght, 256));

        RuleFor(p => p.Age)
            .GreaterThan(0)
            .WithMessage(ActorsMessages.MustBeGraterThanZero);
    }
}
