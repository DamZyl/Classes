using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Persons.DomainServices;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.DeleteAuth
{
    public class DeleteAuthCommandHandler : ICommandHandler<DeleteAuthCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonAuthForId _getPersonAuthForId;

        public DeleteAuthCommandHandler(IUnitOfWork unitOfWork, IGetPersonAuthForId getPersonAuthForId)
        {
            _unitOfWork = unitOfWork;
            _getPersonAuthForId = getPersonAuthForId;
        }
        
        public async Task<Unit> Handle(DeleteAuthCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>().FindByWithIncludesAsync(x => x.Id == request.PersonId,
                includes: i => i.Include(x => x.PersonAuths));
            ExceptionHelper.CheckRule(new PersonDoesNotExistRule(person));
            
            person.DeleteAuthFromPerson(request.AuthId, _getPersonAuthForId);

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}