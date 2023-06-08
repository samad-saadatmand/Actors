﻿using Actors.Domain.Constants;
using FluentValidation;

namespace Actors.Application.Features.Actors.Queries.GetActor;

public class AddActorValidator : AbstractValidator<GetActorQuery>
{
    public AddActorValidator()
    {
        RuleFor(p => p.Id)
           .NotNull()
           .NotEmpty()
           .WithMessage(ActorsMessages.IsRequired);


    }
}
