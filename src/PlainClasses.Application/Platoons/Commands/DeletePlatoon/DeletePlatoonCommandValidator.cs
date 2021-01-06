using FluentValidation;

namespace PlainClasses.Application.Platoons.Commands.DeletePlatoon
{
    public class DeletePlatoonCommandValidator : AbstractValidator<DeletePlatoonCommand>
    {
        public DeletePlatoonCommandValidator()
        {
            RuleFor(x => x.PlatoonId)
                .NotEmpty()
                .WithMessage("Id is empty.");
        }
    }
}