using FluentValidation;

namespace PlainClasses.Application.EduBlocks.Commands.DeleteEduBlock
{
    public class DeleteEduBlockCommandValidator : AbstractValidator<DeleteEduBlockCommand>
    {
        public DeleteEduBlockCommandValidator()
        {
            RuleFor(x => x.EduBlockId)
                .NotEmpty()
                .WithMessage("Id is empty.");
        }
    }
}