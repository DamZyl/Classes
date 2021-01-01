using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PlainClasses.Application.Platoons.Commands.CreatePlatoon
{
    public class CreatePlatoonCommandHandler : IRequestHandler<CreatePlatoonCommand, ReturnPlatoonViewModel>
    {
        public Task<ReturnPlatoonViewModel> Handle(CreatePlatoonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}