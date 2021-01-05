using System;
using PlainClasses.Domain.Platoons;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetPlatoonForId
    {
        Platoon Get(Guid platoonId);
    }
}