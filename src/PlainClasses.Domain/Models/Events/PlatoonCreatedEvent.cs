using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
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