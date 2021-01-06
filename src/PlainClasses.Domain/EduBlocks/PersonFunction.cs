using System;
using PlainClasses.Domain.EduBlocks.Enums;
using PlainClasses.Domain.EduBlocks.Rules;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks
{
    public class PersonFunction : Entity
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid EduBlockId { get; private set; }
        public Function Function { get; private set; }

        #region Ef_Config
        
        public Person Person { get; set; }
        public EduBlock EduBlock { get; set; }
        
        #endregion

        private PersonFunction() { }
        
        private PersonFunction(Guid personId, Guid eduBlockId, string function)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            EduBlockId = eduBlockId;
            Function = Enum.Parse<Function>(function);
        }

        public static PersonFunction CreateFunctionForPersonInEduBlock(Guid personId, Guid eduBlockId, string function)
        {
            CheckRule(new FunctionInEduBlockRule(function));

            return new PersonFunction(personId, eduBlockId, function);
        }
    }
}