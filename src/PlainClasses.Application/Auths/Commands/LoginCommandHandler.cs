using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Auths.Rules;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Extensions;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Auths.Commands
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, ReturnLoginViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<ReturnLoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>()
                .GetOrFailWithIncludesAsync(x => x.PersonalNumber == request.PersonalNumber, 
                    includes: i => i.Include(x => x.PersonAuths));

            ExceptionHelper.CheckRule(new InvalidCredentialRule(_passwordHasher, person, request.Password));
            
            return new ReturnLoginViewModel
                {
                    Token = _jwtHandler.CreateToken(person.Id,
                        $"{person.MilitaryRankAcr} {person.FirstName} {person.LastName}",
                        person.PersonAuths)
                };
        }
    }
}