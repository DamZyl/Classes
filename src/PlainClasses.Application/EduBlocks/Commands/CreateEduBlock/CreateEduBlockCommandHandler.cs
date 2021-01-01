using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockCommandHandler : IRequestHandler<CreateEduBlockCommand, ReturnEduBlockViewModel>
    {
        public Task<ReturnEduBlockViewModel> Handle(CreateEduBlockCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}