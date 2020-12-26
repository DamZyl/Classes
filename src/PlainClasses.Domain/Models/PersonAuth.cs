using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PersonAuth : Entity
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid AuthId { get; private set; }

        #region Ef_Config

        public Person Person { get; set; }
        public Auth Auth { get; set; }

        #endregion

        private PersonAuth() { }
        
        private PersonAuth(Guid personId, Guid authId)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            AuthId = authId;
        }

        public static PersonAuth CreateAuthForPerson(Guid personId, Guid authId)
            => new PersonAuth(personId, authId);
    }
}