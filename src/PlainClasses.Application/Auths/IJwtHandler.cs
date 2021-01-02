using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models;

namespace PlainClasses.Application.Auths
{
    public interface IJwtHandler
    {
        string CreateToken(Guid userId, string fullName, IEnumerable<PersonAuth> auths);
    }
}