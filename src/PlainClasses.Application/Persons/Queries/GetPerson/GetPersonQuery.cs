using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Persons.Queries.GetPerson
{
    public class GetPersonQuery : IQuery<PersonViewModelDetail>
    {
        public Guid Id { get; set; }
    }
}