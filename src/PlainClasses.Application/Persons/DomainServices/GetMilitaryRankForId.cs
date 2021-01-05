using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Persons;

namespace PlainClasses.Application.Persons.DomainServices
{
    public class GetMilitaryRankForId : IGetMilitaryRankForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetMilitaryRankForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public MilitaryRank Get(Guid militaryRankId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlMilitaryRank = "SELECT " +
                                           "[MilitaryRank].[Id], " +
                                           "[MilitaryRank].[Acronym] " +
                                           "FROM MilitaryRanks AS [MilitaryRank] " +
                                           "WHERE [MilitaryRank].[Id] = @MilitaryRankId ";
            
            var militaryRank = connection.QuerySingleOrDefault<MilitaryRank>(sqlMilitaryRank, new { militaryRankId });

            return militaryRank;
        }
    }
}