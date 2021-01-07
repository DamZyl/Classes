using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Persons.Commands.DeleteAuth
{
    public class DeleteAuthCommand : CommandBase
    {
        public Guid PersonId { get; }
        public Guid AuthId { get; }

        public DeleteAuthCommand(Guid personId, Guid authId)
        {
            PersonId = personId;
            AuthId = authId;
        }
    }
}