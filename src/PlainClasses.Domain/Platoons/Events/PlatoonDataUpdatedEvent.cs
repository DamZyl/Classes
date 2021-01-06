using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Events
{
    public class PlatoonDataUpdatedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }

        public PlatoonDataUpdatedEvent(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}