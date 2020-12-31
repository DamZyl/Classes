using System.Text.RegularExpressions;
using PlainClasses.Domain.Models.Utils;
using PlainClasses.Domain.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class NumberFormatRule : IBusinessRule
    {
        private readonly string _phoneNumber;

        public NumberFormatRule(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }
        
        public bool IsBroken()
        {
            var regex = new Regex(Consts.PhoneNumberRegex);

            return !regex.IsMatch(_phoneNumber);
        }

        public string Message => "PhoneNumber should have format 'xxx-xxx-xxx'.";
    }
}