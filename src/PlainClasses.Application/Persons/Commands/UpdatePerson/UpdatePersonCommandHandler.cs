using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Persons.DomainServices;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonForId _getPersonForId;
        private readonly IGetMilitaryRankForId _getMilitaryRankForId;
        private readonly IGetPlatoonForId _getPlatoonForId;
        private readonly IPersonPasswordHasher _passwordHasher;

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork, IGetPersonForId getPersonForId, 
            IGetMilitaryRankForId getMilitaryRankForId, IGetPlatoonForId getPlatoonForId, 
            IPersonPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _getPersonForId = getPersonForId;
            _getMilitaryRankForId = getMilitaryRankForId;
            _getPlatoonForId = getPlatoonForId;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _getPersonForId.GetDetailAsync(request.PersonId);
            ExceptionHelper.CheckRule(new PersonDoesNotExistRule(person));
            
            person.UpdatePersonalData(request.MilitaryRankId, request.PlatoonId, request.Password, request.LastName, 
                request.WorkPhoneNumber, request.PersonalPhoneNumber, request.Position, _passwordHasher, 
                _getMilitaryRankForId, _getPlatoonForId);

            await _unitOfWork.Repository<Person>().EditAsync(person);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}