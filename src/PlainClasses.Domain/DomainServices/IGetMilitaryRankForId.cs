using System;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Domain.DomainServices
{
    public interface IGetMilitaryRankForId
    {
        MilitaryRank Get(Guid militaryRankId);
    }
}