using System;

namespace PlainClasses.Domain.Persons.DomainServices
{
    public interface IGetMilitaryRankForId
    {
        MilitaryRank Get(Guid militaryRankId);
    }
}