using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
{
    public class PersonCreatedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }

        public PersonCreatedEvent(Guid personId)
        {
            PersonId = personId;
        }
    }
}