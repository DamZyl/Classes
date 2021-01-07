using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Commands.CreatePerson;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.AddAuth
{
    public class AddAuthCommandHandler : ICommandHandler<AddAuthCommand, ReturnPersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAuthCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ReturnPersonViewModel> Handle(AddAuthCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>()
                .FindByWithIncludesAsync(x => x.Id == request.PersonId,
                includes: i => i.Include(x => x.PersonAuths));
            ExceptionHelper.CheckRule(new PersonDoesNotExistRule(person));
            
            person.AddAuthToPerson(request.AuthName);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnPersonViewModel { Id =  person.Id };
        }
    }
}