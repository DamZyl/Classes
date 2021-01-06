using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Events
{
    public class PlatoonCreatedEvent : DomainEventBase
    {
        public Guid PlatoonId { get; private set; }

        public PlatoonCreatedEvent(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}