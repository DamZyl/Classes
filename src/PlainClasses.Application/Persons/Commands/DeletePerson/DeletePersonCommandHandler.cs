using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(ISqlConnectionFactory sqlConnectionFactory, IUnitOfWork unitOfWork)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                               "[Person].[Id] " +
                               "FROM Persons AS [Person] " +
                               "WHERE [Person].[Id] = @PersonId ";
            
            var person = await connection.QuerySingleOrDefaultAsync<Person>(sql, new { request.PersonId });
            
            ExceptionHelper.CheckRule(new PersonDoesNotExistRule(person));

            await _unitOfWork.Repository<Person>().DeleteAsync(person);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}