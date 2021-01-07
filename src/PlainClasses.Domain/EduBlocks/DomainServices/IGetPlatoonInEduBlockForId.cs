using System;

namespace PlainClasses.Domain.EduBlocks.DomainServices
{
    public interface IGetPlatoonInEduBlockForId
    {
        PlatoonInEduBlock Get(Guid platoonId, Guid eduBlockId);
    }
}