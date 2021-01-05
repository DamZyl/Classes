using System;
using System.Threading.Tasks;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetPersonForId
    {
        Person Get(Guid personId);
        Task<Person> GetAsync(Guid personId);
    }
}