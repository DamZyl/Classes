using System;

namespace PlainClasses.Application.Auths.Commands.Login
{
    public class AuthDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string AuthName { get; set; }
    }
}