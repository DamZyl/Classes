using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Queries.GetPlatoons
{
    public class GetPlatoonsQueryHandler : IQueryHandler<GetPlatoonsQuery, IEnumerable<PlatoonViewModel>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<IEnumerable<PlatoonViewModel>> Handle(GetPlatoonsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Platoon].[Id], " +
                               "[Platoon].[Name], " +
                               "[Platoon].[Acronym], " +
                               "[Platoon].[Commander], " +
                               "COUNT(PlatoonId) AS [PersonCount] " +
                               "FROM Persons AS [Person] " +
                               "RIGHT JOIN Platoons AS [Platoon] ON  [Person].[PlatoonId] = [Platoon].[Id]" + 
                               "GROUP BY [Platoon].[Id], [Platoon].[Name], [Platoon].[Acronym], [Platoon].[Commander] ";
            
            var platoons = await connection.QueryAsync<PlatoonViewModel>(sql);

            return platoons;
        }
    }
}