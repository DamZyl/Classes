using System;
using System.Threading.Tasks;
using PlainClasses.Domain.EduBlocks;

namespace PlainClasses.Domain.Utils.SharedKernels.DomainServices
{
    public interface IGetEduBlockForId
    {
        EduBlock Get(Guid eduBlockId);
        Task<EduBlock> GetAsync(Guid eduBlockId);
        Task<EduBlock> GetDetailAsync(Guid eduBlockId);
    }
}