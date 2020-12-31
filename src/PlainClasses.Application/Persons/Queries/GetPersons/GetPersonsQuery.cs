using System.Collections.Generic;
using PlainClasses.Application.Dispatchers;

namespace PlainClasses.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQuery : IQuery<IEnumerable<PersonViewModel>> { }
}