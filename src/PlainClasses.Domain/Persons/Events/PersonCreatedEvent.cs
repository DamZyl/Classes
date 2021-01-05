using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Events
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