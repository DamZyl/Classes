using System;
using PlainClasses.Domain.Models;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetEduBlockSubjectForId
    {
        EduBlockSubject Get(Guid eduBlockSubjectId);
    }
}