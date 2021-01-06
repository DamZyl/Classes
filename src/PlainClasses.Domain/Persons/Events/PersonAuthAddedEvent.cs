using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Events
{
    public class PersonAuthAddedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }
        public string AuthName { get; private set; }

        public PersonAuthAddedEvent(Guid personId, string authName)
        {
            PersonId = personId;
            AuthName = authName;
        }
    }
}