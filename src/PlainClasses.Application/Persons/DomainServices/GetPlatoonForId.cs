using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Persons.DomainServices
{
    public class GetPlatoonForId : IGetPlatoonForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public Platoon Get(Guid platoonId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoon = "SELECT " + 
                                      "[Platoon].[Id], " +
                                      "[Platoon].[Acronym] " +
                                      "FROM Platoons AS [Platoon] " +
                                      "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = connection.QuerySingleOrDefault<Platoon>(sqlPlatoon, new { platoonId });

            return platoon;
        }
    }
}