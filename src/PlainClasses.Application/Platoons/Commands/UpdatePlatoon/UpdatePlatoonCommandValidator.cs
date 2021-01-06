using FluentValidation;

namespace PlainClasses.Application.Platoons.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommandValidator : AbstractValidator<UpdatePlatoonCommand>
    {
        public UpdatePlatoonCommandValidator()
        {
            RuleFor(x => x.Commander)
                .NotEmpty()
                .WithMessage("Commander is empty.");
        }
    }
}