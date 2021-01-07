using System;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Domain.Platoons.DomainServices
{
    public interface IChangePlatoonForPerson
    {
        void ChangePlatoon(Person person, Guid platoonId);
        void ChangePlatoon(Person person);
    }
}