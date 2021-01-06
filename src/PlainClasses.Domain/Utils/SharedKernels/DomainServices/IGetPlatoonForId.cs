using System;
using System.Threading.Tasks;
using PlainClasses.Domain.Platoons;

namespace PlainClasses.Domain.Utils.SharedKernels.DomainServices
{
    public interface IGetPlatoonForId
    {
        Platoon Get(Guid platoonId);
        Task<Platoon> GetAsync(Guid platoonId);
        Task<Platoon> GetDetailAsync(Guid platoonId);
    }
}