using FluentValidation;

namespace PlainClasses.Application.EduBlocks.Commands.DeletePlatoon
{
    public class DeletePlatoonFromEduBlockCommandValidator : AbstractValidator<DeletePlatoonFromEduBlockCommand>
    {
        public DeletePlatoonFromEduBlockCommandValidator()
        {
            RuleFor(x => x.EduBlockId)
                .NotEmpty()
                .WithMessage("EduBlockId is empty.");
            
            RuleFor(x => x.PlatoonId)
                .NotEmpty()
                .WithMessage("PlatoonId is empty.");
        }
    }
}