﻿using System;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Rules;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PersonFunction : Entity
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid EduBlockId { get; set; }
        public Function Function { get; set; }

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