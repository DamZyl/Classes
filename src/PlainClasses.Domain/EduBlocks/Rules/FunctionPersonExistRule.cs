using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class FunctionPersonExistRule : IBusinessRule
    {
        private readonly PersonFunction _functionPerson;

        public FunctionPersonExistRule(PersonFunction functionPerson)
        {
            _functionPerson = functionPerson;
        }

        public bool IsBroken() => _functionPerson == null;

        public string Message => $"Function person does not exist.";
    }
}