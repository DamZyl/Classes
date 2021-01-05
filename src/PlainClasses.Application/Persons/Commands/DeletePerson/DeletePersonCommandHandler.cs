using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonForId _getPersonForId;

        public DeletePersonCommandHandler(IUnitOfWork unitOfWork, IGetPersonForId getPersonForId)
        {
            _unitOfWork = unitOfWork;
            _getPersonForId = getPersonForId;
        }
        
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _getPersonForId.GetAsync(request.PersonId);
            ExceptionHelper.CheckRule(new PersonDoesNotExistRule(person));

            await _unitOfWork.Repository<Person>().DeleteAsync(person);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}