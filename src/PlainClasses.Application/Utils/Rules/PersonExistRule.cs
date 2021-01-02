using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Application.Utils.Rules
{
    public class PersonExistRule : IBusinessRule
    {
        public bool IsBroken()
        {
            throw new System.NotImplementedException();
        }

        public string Message { get; }
    }
}