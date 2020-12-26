using PlainClasses.Domain.Extensions;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class PersonalNumberValidRule : IBusinessRule
    {
        private readonly string _personalNumber;

        public PersonalNumberValidRule(string personalNumber)
        {
            _personalNumber = personalNumber;
        }

        public bool IsBroken() => !_personalNumber.IsPersonalNumberValid();

        public string Message => $"Personal number: {_personalNumber} isn't correct.";
    }
}