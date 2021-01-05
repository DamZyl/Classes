using System;
using PlainClasses.Domain.EduBlocks;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetEduBlockSubjectForId
    {
        EduBlockSubject Get(Guid eduBlockSubjectId);
    }
}