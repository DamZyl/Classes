using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : CommandBase
    {
        public Guid PersonId { get; set; }

        public DeletePersonCommand(Guid personId)
        {
            PersonId = personId;
        }
    }
}