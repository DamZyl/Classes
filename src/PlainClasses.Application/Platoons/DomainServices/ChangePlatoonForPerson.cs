using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Platoons.DomainServices;

namespace PlainClasses.Application.Platoons.DomainServices
{
    public class ChangePlatoonForPerson : IChangePlatoonForPerson
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ChangePlatoonForPerson(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public void ChangePlatoon(Person person, Guid platoonId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoon = "SELECT " + 
                                      "[Platoon].[Id], " +
                                      "[Platoon].[Acronym] " +
                                      "FROM Platoons AS [Platoon] " +
                                      "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = connection.QuerySingleOrDefault<Platoon>(sqlPlatoon, new { platoonId });

            if (person.PlatoonId != platoon.Id)
            {
                person.ChangePlatoon(platoon);
            }
        }
    }
}