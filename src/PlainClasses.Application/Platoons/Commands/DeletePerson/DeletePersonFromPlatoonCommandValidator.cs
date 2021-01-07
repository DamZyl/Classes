using FluentValidation;

namespace PlainClasses.Application.Platoons.Commands.DeletePerson
{
    public class DeletePersonFromPlatoonCommandValidator : AbstractValidator<DeletePersonFromPlatoonCommand>
    {
        public DeletePersonFromPlatoonCommandValidator()
        {
            RuleFor(x => x.PlatoonId)
                .NotEmpty()
                .WithMessage("PlatoonId is empty.");

            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("PersonId is empty.");
        }
    }
}