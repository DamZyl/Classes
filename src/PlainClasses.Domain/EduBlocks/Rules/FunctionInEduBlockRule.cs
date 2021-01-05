using System;
using PlainClasses.Domain.EduBlocks.Enums;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class FunctionInEduBlockRule : IBusinessRule
    {
        private readonly string _function;

        public FunctionInEduBlockRule(string function)
        {
            _function = function;
        }

        public bool IsBroken() => !Enum.IsDefined(typeof(Function), _function);

        public string Message => $"Function: {_function} doesn't exist.";
    }
}