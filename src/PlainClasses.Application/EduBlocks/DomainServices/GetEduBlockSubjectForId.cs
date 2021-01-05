using System;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;

namespace PlainClasses.Application.EduBlocks.DomainServices
{
    public class GetEduBlockSubjectForId : IGetEduBlockSubjectForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEduBlockSubjectForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public EduBlockSubject Get(Guid eduBlockSubjectId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlEduBlockSubject = "SELECT " +
                                           "[EduBlockSubject].[Id], " +
                                           "[EduBlockSubject].[Name] " +
                                           "FROM EduBlockSubjects AS [EduBlockSubject] " +
                                           "WHERE [EduBlockSubject].[Id] = @EduBlockSubjectId ";
            
            var eduBlockSubject = connection.QuerySingleOrDefault<EduBlockSubject>(sqlEduBlockSubject, new { eduBlockSubjectId });

            return eduBlockSubject;
        }
    }
}