using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Events
{
    public class PersonAuthDeletedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }
        public Guid PersonAuthId { get; private set; }
        

        public PersonAuthDeletedEvent(Guid personId, Guid personAuthId)
        {
            PersonId = personId;
            PersonAuthId = personAuthId;
        }
    }
}