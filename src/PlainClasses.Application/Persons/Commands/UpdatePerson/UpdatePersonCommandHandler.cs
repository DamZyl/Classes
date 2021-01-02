using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        public Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}