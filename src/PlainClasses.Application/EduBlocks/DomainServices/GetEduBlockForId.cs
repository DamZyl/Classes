using System;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.EduBlocks;

namespace PlainClasses.Application.EduBlocks.DomainServices
{
    public class GetEduBlockForId : IGetEduBlockForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEduBlockForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public EduBlock Get(Guid eduBlockId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[EduBlock].[Id] " +
                               "FROM EduBlocks AS [EduBlock] " +
                               "WHERE [EduBlock].[Id] = @EduBlockId ";
            
            var eduBlock = connection.QuerySingleOrDefault<EduBlock>(sql, new { eduBlockId });

            return eduBlock;
        }

        public async Task<EduBlock> GetAsync(Guid eduBlockId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[EduBlock].[Id] " +
                               "FROM EduBlocks AS [EduBlock] " +
                               "WHERE [EduBlock].[Id] = @EduBlockId ";
            
            var eduBlock = await connection.QuerySingleOrDefaultAsync<EduBlock>(sql, new { eduBlockId });

            return eduBlock;
        }
    }
}