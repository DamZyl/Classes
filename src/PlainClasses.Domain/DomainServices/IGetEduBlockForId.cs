using System;
using System.Threading.Tasks;
using PlainClasses.Domain.EduBlocks;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetEduBlockForId
    {
        EduBlock Get(Guid eduBlockId);
        Task<EduBlock> GetAsync(Guid eduBlockId);
    }
}