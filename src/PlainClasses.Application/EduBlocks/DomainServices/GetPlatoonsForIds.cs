using System;
using System.Collections.Generic;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;

namespace PlainClasses.Application.EduBlocks.DomainServices
{
    public class GetPlatoonsForIds : IGetPlatoonsForIds
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonsForIds(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public IEnumerable<Platoon> Get(IEnumerable<Guid> platoonIds)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoons = "SELECT " + 
                                       "[Platoon].[Id], " +
                                       "[Platoon].[Name] " +
                                       "FROM Platoons AS [Platoon] " +
                                       "WHERE [Platoon].[Id] IN @platoonIds ";
            
            var platoons = connection.Query<Platoon>(sqlPlatoons, new { platoonIds });

            return platoons;
        }
    }
}