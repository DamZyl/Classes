using FluentValidation;

namespace PlainClasses.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("Id is empty.");
        }
    }
}