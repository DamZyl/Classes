using FluentValidation;

namespace PlainClasses.Application.Persons.Commands.AddAuth
{
    public class AddAuthCommandValidator : AbstractValidator<AddAuthCommand>
    {
        public AddAuthCommandValidator()
        {
            RuleFor(x => x.AuthName)
                .NotEmpty()
                .WithMessage("AuthName is empty.");
        }
    }
}