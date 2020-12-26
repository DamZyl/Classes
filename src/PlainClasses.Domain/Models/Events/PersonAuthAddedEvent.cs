using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
{
    public class PersonAuthAddedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }
        public Guid AuthId { get; private set; }

        public PersonAuthAddedEvent(Guid personId, Guid authId)
        {
            PersonId = personId;
            AuthId = authId;
        }
    }
}