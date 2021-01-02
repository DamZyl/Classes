using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQueryHandler : IQueryHandler<GetPersonsQuery, IEnumerable<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<PersonViewModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _unitOfWork.Repository<Person>().GetAllAsync();

            return persons.Select(Mapper.MapPersonToPersonViewModel);
        }
    }
}