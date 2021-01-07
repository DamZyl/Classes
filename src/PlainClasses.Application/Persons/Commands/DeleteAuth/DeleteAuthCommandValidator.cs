using FluentValidation;

namespace PlainClasses.Application.Persons.Commands.DeleteAuth
{
    public class DeleteAuthCommandValidator : AbstractValidator<DeleteAuthCommand>
    {
        public DeleteAuthCommandValidator()
        {
            RuleFor(x => x.AuthId)
                .NotEmpty()
                .WithMessage("AuthId is empty.");
            
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("PersonId is empty.");
        }
    }
}