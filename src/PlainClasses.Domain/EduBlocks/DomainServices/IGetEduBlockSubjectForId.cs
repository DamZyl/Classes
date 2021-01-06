using System;

namespace PlainClasses.Domain.EduBlocks.DomainServices
{
    public interface IGetEduBlockSubjectForId
    {
        EduBlockSubject Get(Guid eduBlockSubjectId);
    }
}