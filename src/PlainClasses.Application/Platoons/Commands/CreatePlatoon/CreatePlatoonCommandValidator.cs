using FluentValidation;

namespace PlainClasses.Application.Platoons.Commands.CreatePlatoon
{
    public class CreatePlatoonCommandValidator : AbstractValidator<CreatePlatoonCommand>
    {
        public CreatePlatoonCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is empty.");
           
            RuleFor(x => x.Acronym)
                .NotEmpty()
                .WithMessage("Acronym is empty.");
            
            RuleFor(x => x.Commander)
                .NotEmpty()
                .WithMessage("Commander is empty.");
        }
    }
}