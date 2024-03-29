using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQueryHandler : IQueryHandler<GetPersonsQuery, IEnumerable<PersonViewModel>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPersonsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public async Task<IEnumerable<PersonViewModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
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
                               "FROM Persons AS [Person] ";
            
            var persons = await connection.QueryAsync<PersonViewModel>(sql);

            return persons;
        }
    }
}