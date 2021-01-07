using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Events
{
    public class PersonFromPlatoonDeletedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }
        public Guid PersonId { get; private set; }

        public PersonFromPlatoonDeletedEvent(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}