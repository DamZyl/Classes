using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PersonAuth : Entity
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public string AuthName { get; private set; }

        #region Ef_Config

        public Person Person { get; set; }
        
        #endregion

        private PersonAuth() { }
        
        private PersonAuth(Guid personId, string authName)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            AuthName = authName;
        }

        public static PersonAuth CreateAuthForPerson(Guid personId, string authName)
            => new PersonAuth(personId, authName);
    }
}