using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Events
{
    public class PersonDataUpdatedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }

        public PersonDataUpdatedEvent(Guid personId)
        {
            PersonId = personId;
        }
    }
}