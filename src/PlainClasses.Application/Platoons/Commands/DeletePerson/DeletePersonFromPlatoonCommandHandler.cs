using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Platoons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Platoons.DomainServices;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Platoons.Commands.DeletePerson
{
    public class DeletePersonFromPlatoonCommandHandler : ICommandHandler<DeletePersonFromPlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonForId _getPersonForId;
        private readonly IChangePlatoonForPerson _changePlatoonForPerson;

        public DeletePersonFromPlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPersonForId getPersonForId, 
            IChangePlatoonForPerson changePlatoonForPerson)
        {
            _unitOfWork = unitOfWork;
            _getPersonForId = getPersonForId;
            _changePlatoonForPerson = changePlatoonForPerson;
        }
        
        public async Task<Unit> Handle(DeletePersonFromPlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _unitOfWork.Repository<Platoon>()
                .FindByWithIncludesAsync(x => x.Id == request.PlatoonId,
                    includes: i => i.Include(x => x.Persons));
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));
            
            platoon.DeletePersonFromPlatoon(request.PersonId, _getPersonForId, _changePlatoonForPerson);

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}