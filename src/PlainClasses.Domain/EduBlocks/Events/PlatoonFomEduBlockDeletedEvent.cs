using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Events
{
    public class PlatoonFomEduBlockDeletedEvent : DomainEventBase
    {
        public Guid EduBlockId { get; private set; }
        public Guid PlatoonId { get; private set; }

        public PlatoonFomEduBlockDeletedEvent(Guid eduBlockId, Guid platoonId)
        {
            EduBlockId = eduBlockId;
            PlatoonId = platoonId;
        }
    }
}