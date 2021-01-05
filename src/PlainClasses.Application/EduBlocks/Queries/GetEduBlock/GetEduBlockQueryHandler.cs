using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Rules;
using PlainClasses.Application.Utils;

namespace PlainClasses.Application.EduBlocks.Queries.GetEduBlock
{
    public class GetEduBlockQueryHandler : IQueryHandler<GetEduBlockQuery, EduBlockDetailViewModel>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEduBlockQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<EduBlockDetailViewModel> Handle(GetEduBlockQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[EduBlock].[Id], " +
                               "[EduBlock].[EduBlockSubjectName], " +
                               "[EduBlock].[StartEduBlock], " +
                               "[EduBlock].[EndEduBlock], " +
                               "[EduBlock].[Place], " +
                               "[EduBlock].[Remarks] " +
                               "FROM EduBlocks AS [EduBlock] " +
                               "WHERE [EduBlock].[Id] = @Id ";
            
            var eduBlock = await connection.QuerySingleOrDefaultAsync<EduBlockDetailViewModel>(sql, new { request.Id });
            
            ExceptionHelper.CheckRule(new EduBlockExistRule(eduBlock));
            
            const string sqlFunctions = "SELECT " +
                                    "[PersonFunction].[Id], " +
                                    "(SELECT [Person].[MilitaryRankAcr] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] " + 
                                        "FROM Persons AS [Person] " + 
                                        "WHERE [Person].[Id] = [PersonFunction].[PersonId]) AS Person," +
                                    "[PersonFunction].[Function] " +
                                    "FROM PersonFunctions AS [PersonFunction] " +
                                    "WHERE [PersonFunction].[EduBlockId] = @Id ";
            
            var functions = await connection.QueryAsync<PersonFunctionViewModel>(sqlFunctions, new { eduBlock.Id });
            eduBlock.PersonFunctions = functions.AsList();
            
            const string sqlPlatoons = "SELECT " +
                                        "[PlatoonInEduBlock].[Id], " +
                                        "(SELECT [Platoon].[Acronym] " + 
                                            "FROM Platoons AS [Platoon] " +
                                            "WHERE [Platoon].[Id] = [PlatoonInEduBlock].[PlatoonId]) AS Platoon " +
                                        "FROM PlatoonInEduBlocks AS [PlatoonInEduBlock] " +
                                        "WHERE [PlatoonInEduBlock].[EduBlockId] = @Id ";
            
            var platoons = await connection.QueryAsync<PlatoonInEduBlockViewModel>(sqlPlatoons, new { eduBlock.Id });
            eduBlock.PlatoonsInEduBlock = platoons.AsList();

            return eduBlock;
        }
    }
}