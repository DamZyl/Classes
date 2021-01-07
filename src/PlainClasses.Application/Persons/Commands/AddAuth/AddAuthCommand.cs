using System;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Persons.Commands.CreatePerson;

namespace PlainClasses.Application.Persons.Commands.AddAuth
{
    public class AddAuthCommand : CommandBase<ReturnPersonViewModel>
    {
        public Guid PersonId { get; }
        public string AuthName { get; }

        public AddAuthCommand(Guid personId, string authName)
        {
            PersonId = personId;
            AuthName = authName;
        }
    }
}