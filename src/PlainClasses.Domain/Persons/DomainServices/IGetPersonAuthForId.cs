using System;

namespace PlainClasses.Domain.Persons.DomainServices
{
    public interface IGetPersonAuthForId
    {
        PersonAuth Get(Guid authId);
    }
}