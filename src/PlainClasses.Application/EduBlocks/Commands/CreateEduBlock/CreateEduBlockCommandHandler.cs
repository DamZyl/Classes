using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockCommandHandler : ICommandHandler<CreateEduBlockCommand, ReturnEduBlockViewModel>
    {
        public Task<ReturnEduBlockViewModel> Handle(CreateEduBlockCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}