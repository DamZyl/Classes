using System;
using PlainClasses.Domain.Models;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetPlatoonForId
    {
        Platoon Get(Guid platoonId);
    }
}