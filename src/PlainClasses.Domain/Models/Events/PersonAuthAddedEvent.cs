using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
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