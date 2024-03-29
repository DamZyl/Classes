using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;

namespace PlainClasses.Application.Persons.Queries.GetPerson
{
    public class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonViewModelDetail>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPersonQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<PersonViewModelDetail> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Person].[Id], " +
                               "[Person].[PersonalNumber], " +
                               "[Person].[MilitaryRankAcr] + ' ' + [Person].[FirstName] + ' ' + [Person].[LastName] AS [FullName], " +
                               "[Person].[FatherName], " +
                               "[Person].[BirthDate], " +
                               "[Person].[PlatoonAcr], " +
                               "[Person].[WorkPhoneNumber], " +
                               "[Person].[PersonalPhoneNumber], " +
                               "[Person].[Position] " +
                               "FROM Persons AS [Person] " +
                               "WHERE [Person].[Id] = @Id ";
            
            var person = await connection.QuerySingleOrDefaultAsync<PersonViewModelDetail>(sql, new { request.Id });
            
            ExceptionHelper.CheckRule(new PersonExistRule(person));
            
            const string sqlAuths = "SELECT " +
                                    "[AuthPerson].[Id], " +
                                    "[AuthPerson].[PersonId], " +
                                    "[AuthPerson].[AuthName] " +
                                    "FROM PersonAuths AS [AuthPerson] " +
                                    "WHERE [AuthPerson].[PersonId] = @Id ";
            
            var auths = await connection.QueryAsync<AuthViewModel>(sqlAuths, new { person.Id });

            person.PersonAuths = auths.AsList();

            return person;
        }
    }
}