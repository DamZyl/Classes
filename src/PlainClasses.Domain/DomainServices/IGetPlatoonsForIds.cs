using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetPlatoonsForIds
    {
        IEnumerable<Platoon> Get(IEnumerable<Guid> platoonIds);
    }
}