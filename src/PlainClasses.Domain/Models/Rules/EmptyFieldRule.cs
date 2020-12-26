using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class EmptyFieldRule : IBusinessRule
    {
        private readonly string _field;

        public EmptyFieldRule(string field)
        {
            _field = field;
        }

        public bool IsBroken() => string.IsNullOrWhiteSpace(_field);

        public string Message => $"{nameof(_field)} should not be empty.";
    }
}