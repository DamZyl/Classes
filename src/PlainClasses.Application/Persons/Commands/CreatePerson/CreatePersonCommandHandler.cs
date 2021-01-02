using System.Threading;
using System.Threading.Tasks;
using Dapper;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, ReturnPersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IPersonPasswordHasher _passwordHasher;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork, ISqlConnectionFactory sqlConnectionFactory,
            IPersonPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _sqlConnectionFactory = sqlConnectionFactory;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<ReturnPersonViewModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlMilitaryRank = "SELECT " +
                               "[MilitaryRank].[Id], " +
                               "[MilitaryRank].[Acronym] " +
                               "FROM MilitaryRanks AS [MilitaryRank] " +
                               "WHERE [MilitaryRank].[Id] = @MilitaryRankId ";
            
            var militaryRank = await connection.QuerySingleOrDefaultAsync<MilitaryRankDto>(sqlMilitaryRank, new { request.MilitaryRankId });
            
            const string sqlPlatoon = "SELECT " + 
                                "[Platoon].[Id], " +
                                "[Platoon].[Acronym] " +
                                "FROM Platoons AS [Platoon] " +
                                "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = await connection.QuerySingleOrDefaultAsync<PlatoonDto>(sqlPlatoon, new { request.PlatoonId });

            var person = Person.CreatePerson(militaryRank.Id, militaryRank.Acronym, 
                platoon.Id, platoon.Acronym, request.PersonalNumber, request.Password, 
                request.FirstName, request.LastName, request.FatherName, request.BirthDate, request.WorkPhoneNumber,
                request.PersonalPhoneNumber, request.Position, _passwordHasher);

            await _unitOfWork.Repository<Person>().AddAsync(person);
            await _unitOfWork.CommitAsync();

            return new ReturnPersonViewModel { Id = person.Id };
        }
    }
}