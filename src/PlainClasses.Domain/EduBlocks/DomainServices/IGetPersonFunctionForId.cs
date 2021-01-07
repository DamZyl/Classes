using System;

namespace PlainClasses.Domain.EduBlocks.DomainServices
{
    public interface IGetPersonFunctionForId
    {
        PersonFunction Get(Guid functionId);
    }
}