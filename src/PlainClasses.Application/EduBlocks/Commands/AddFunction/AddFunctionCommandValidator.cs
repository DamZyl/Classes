using FluentValidation;

namespace PlainClasses.Application.EduBlocks.Commands.AddFunction
{
    public class AddFunctionCommandValidator : AbstractValidator<AddFunctionCommand>
    {
        public AddFunctionCommandValidator()
        {
            RuleFor(x => x.Function)
                .NotEmpty()
                .WithMessage("Function is empty.");
            
            RuleFor(x => x.EduBlockId)
                .NotEmpty()
                .WithMessage("EduBlockId is empty.");
            
            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("PersonId is empty.");
        }
    }
}