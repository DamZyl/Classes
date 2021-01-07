using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.EduBlocks.DomainServices;

namespace PlainClasses.Application.EduBlocks.DomainServices
{
    public class GetPersonFunctionForId : IGetPersonFunctionForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPersonFunctionForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public PersonFunction Get(Guid functionId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlFunctions = "SELECT " +
                                       "[PersonFunction].[Id] " +
                                       "FROM PersonFunctions AS [PersonFunction] " +
                                       "WHERE [PersonFunction].[Id] = @functionId ";
            
            var functionPerson = connection.QuerySingleOrDefault<PersonFunction>(sqlFunctions, new { functionId });

            return functionPerson;
        }
    }
}