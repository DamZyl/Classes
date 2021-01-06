using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Platoons.Rules;
using PlainClasses.Application.Utils;

namespace PlainClasses.Application.Platoons.Queries.GetPlatoon
{
    public class GetPlatoonQueryHandler : IQueryHandler<GetPlatoonQuery, PlatoonDetailViewModel>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<PlatoonDetailViewModel> Handle(GetPlatoonQuery request, CancellationToken cancellationToken)
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
                               "WHERE [Platoon].[Id] = @Id " +
                               "GROUP BY [Platoon].[Id], [Platoon].[Name], [Platoon].[Acronym], [Platoon].[Commander] ";

            var platoon = await connection.QuerySingleOrDefaultAsync<PlatoonDetailViewModel>(sql, new { request.Id });
            
            ExceptionHelper.CheckRule(new PlatoonExistsRule(platoon));
            
            const string sqlPersons = "SELECT " +
                                      "[Person].[Id], " +
                                      "[Person].[PersonalNumber], " +
                                      "[Person].[MilitaryRankAcr] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] AS [FullName], " +
                                      "[Person].[FatherName], " +
                                      "[Person].[BirthDate], " +
                                      "[Person].[WorkPhoneNumber], " +
                                      "[Person].[PersonalPhoneNumber], " +
                                      "[Person].[Position] " +
                                      "FROM Persons AS [Person] " +
                                      "WHERE [Person].[PlatoonId] = @Id ";
            
            var persons = await connection.QueryAsync<PersonForPlatoonViewModel>(sqlPersons, new { platoon.Id });
            platoon.Persons = persons.AsList();

            return platoon;
        }
    }
}