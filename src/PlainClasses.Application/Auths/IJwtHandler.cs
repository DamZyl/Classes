using System;
using System.Collections.Generic;
using PlainClasses.Application.Auths.Commands.Login;

namespace PlainClasses.Application.Auths
{
    public interface IJwtHandler
    {
        string CreateToken(Guid userId, string fullName, IEnumerable<AuthDto> auths);
    }
}