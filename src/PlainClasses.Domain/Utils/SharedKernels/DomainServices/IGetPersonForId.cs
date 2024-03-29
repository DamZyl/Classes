using System;
using System.Threading.Tasks;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Domain.Utils.SharedKernels.DomainServices
{
    public interface IGetPersonForId
    {
        Person Get(Guid personId);
        Person GetDetail(Guid personId);
        Task<Person> GetAsync(Guid personId);
        Task<Person> GetDetailAsync(Guid personId);
    }
}