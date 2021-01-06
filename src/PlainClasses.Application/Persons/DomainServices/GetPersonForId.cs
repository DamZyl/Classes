using System;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Persons.DomainServices
{
    public class GetPersonForId : IGetPersonForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPersonForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public Person Get(Guid personId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Person].[Id] " +
                               "FROM Persons AS [Person] " +
                               "WHERE [Person].[Id] = @PersonId ";
            
            var person = connection.QuerySingleOrDefault<Person>(sql, new { personId });

            return person;
        }

        public async Task<Person> GetAsync(Guid personId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Person].[Id] " +
                               "FROM Persons AS [Person] " +
                               "WHERE [Person].[Id] = @PersonId ";
            
            var person = await connection.QuerySingleOrDefaultAsync<Person>(sql, new { personId });

            return person;
        }
        
        public async Task<Person> GetDetailAsync(Guid personId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Person].[Id], " +
                               "[Person].[PersonalNumber], " +
                               "[Person].[Password], " +
                               "[Person].[MilitaryRankId], " +
                               "[Person].[MilitaryRankAcr], " +
                               "[Person].[PlatoonId], " +
                               "[Person].[PlatoonAcr], " +
                               "[Person].[FirstName], " +
                               "[Person].[LastName], " +
                               "[Person].[FatherName], " +
                               "[Person].[BirthDate], " +
                               "[Person].[WorkPhoneNumber], " +
                               "[Person].[PersonalPhoneNumber], " +
                               "[Person].[Position] " +
                               "FROM Persons AS [Person] " +
                               "WHERE [Person].[Id] = @PersonId ";
            
            var person = await connection.QuerySingleOrDefaultAsync<Person>(sql, new { personId });

            return person;
        }
    }
}