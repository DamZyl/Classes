using System;
using System.Collections.Generic;
using PlainClasses.Domain.Platoons;

namespace PlainClasses.Domain.EduBlocks.DomainServices
{
    public interface IGetPlatoonsForIds
    {
        IEnumerable<Platoon> Get(IEnumerable<Guid> platoonIds);
    }
}