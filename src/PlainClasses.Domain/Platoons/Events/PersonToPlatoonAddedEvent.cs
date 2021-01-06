using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Events
{
    public class PersonToPlatoonAddedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }
        public Guid PersonId { get; private set; }

        public PersonToPlatoonAddedEvent(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}