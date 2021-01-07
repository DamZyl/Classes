using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.EduBlocks.DomainServices;

namespace PlainClasses.Application.EduBlocks.DomainServices
{
    public class GetPlatoonInEduBlockForId : IGetPlatoonInEduBlockForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonInEduBlockForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public PlatoonInEduBlock Get(Guid platoonId, Guid eduBlockId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoons = "SELECT " + 
                                       "[PlatoonInEduBlock].[PlatoonId] " +
                                       "FROM PlatoonInEduBlocks AS [PlatoonInEduBlock] " +
                                       "WHERE [PlatoonInEduBlock].[PlatoonId] = @platoonId AND " +
                                            "[PlatoonInEduBlock].[EduBlockId] = @eduBlockId";
            
            var platoon = connection.QuerySingleOrDefault<PlatoonInEduBlock>(sqlPlatoons, new { platoonId, eduBlockId });

            return platoon;
        }
    }
}