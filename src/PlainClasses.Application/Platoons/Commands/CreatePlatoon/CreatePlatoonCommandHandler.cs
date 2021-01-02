using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Commands.CreatePlatoon
{
    public class CreatePlatoonCommandHandler : ICommandHandler<CreatePlatoonCommand, ReturnPlatoonViewModel>
    {
        public Task<ReturnPlatoonViewModel> Handle(CreatePlatoonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}