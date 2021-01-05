using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, ReturnPersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonPasswordHasher _passwordHasher;
        private readonly IGetMilitaryRankForId _getMilitaryRankForId;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork, IPersonPasswordHasher passwordHasher, 
            IGetMilitaryRankForId getMilitaryRankForId, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _getMilitaryRankForId = getMilitaryRankForId;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<ReturnPersonViewModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = Person.CreatePerson(request.MilitaryRankId, request.PlatoonId, request.PersonalNumber, request.Password, 
                request.FirstName, request.LastName, request.FatherName, request.BirthDate, request.WorkPhoneNumber,
                request.PersonalPhoneNumber, request.Position, _passwordHasher, _getMilitaryRankForId, _getPlatoonForId);

            await _unitOfWork.Repository<Person>().AddAsync(person);
            await _unitOfWork.CommitAsync();

            return new ReturnPersonViewModel { Id = person.Id };
        }
    }
}