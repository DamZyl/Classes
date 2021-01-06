using System;
using System.Threading.Tasks;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Domain.Utils.SharedKernels.DomainServices
{
    public interface IGetPersonForId
    {
        Person Get(Guid personId);
        Task<Person> GetAsync(Guid personId);
    }
}