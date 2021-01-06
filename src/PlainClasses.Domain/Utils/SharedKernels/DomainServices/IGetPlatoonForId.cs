using System;
using PlainClasses.Domain.Platoons;

namespace PlainClasses.Domain.Utils.SharedKernels.DomainServices
{
    public interface IGetPlatoonForId
    {
        Platoon Get(Guid platoonId);
    }
}