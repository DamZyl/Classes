using System;
using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class FunctionPersonExistsInEduBlockRule : IBusinessRule
    {
        private readonly IEnumerable<PersonFunction> _functionPersons;
        private readonly Guid _functionId;

        public FunctionPersonExistsInEduBlockRule(IEnumerable<PersonFunction> functionPersons, Guid functionId)
        {
            _functionPersons = functionPersons;
            _functionId = functionId;
        } 
        
        public bool IsBroken() => _functionPersons.All(x => x.Id != _functionId);

        public string Message => $"Function person with id: {_functionId} is not in edu block.";
    }
}