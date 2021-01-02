using System;
using PlainClasses.Domain.Models;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetMilitaryRankForId
    {
        MilitaryRank Get(Guid militaryRankId);
    }
}