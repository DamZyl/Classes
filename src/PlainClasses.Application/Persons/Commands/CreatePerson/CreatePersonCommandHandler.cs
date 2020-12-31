using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Extensions;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ReturnPersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ReturnPersonViewModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var militaryRank = await _unitOfWork.Repository<MilitaryRank>().GetOrFailAsync(request.MilitaryRankId);
            var platoon = await _unitOfWork.Repository<Platoon>().GetOrFailAsync(request.PlatoonId);

            var person = Person.CreatePerson(militaryRank, platoon, request.PersonalNumber, request.FirstName,
                request.LastName, request.FatherName, request.BirthDate, request.WorkPhoneNumber,
                request.PersonalPhoneNumber, request.Position);

            await _unitOfWork.Repository<Person>().AddAsync(person);
            await _unitOfWork.CommitAsync();

            return new ReturnPersonViewModel { Id = person.Id };
        }
    }
}