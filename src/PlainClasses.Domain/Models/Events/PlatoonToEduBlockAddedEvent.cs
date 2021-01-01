using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
{
    public class PlatoonToEduBlockAddedEvent : DomainEventBase
    {
        public Guid EduBlockId { get; private set; }
        public Guid PlatoonId { get; private set; }

        public PlatoonToEduBlockAddedEvent(Guid eduBlockId, Guid platoonId)
        {
            EduBlockId = eduBlockId;
            PlatoonId = platoonId;
        }
    }
}