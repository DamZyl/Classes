using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class OverEighteenRule : IBusinessRule
    {
        private readonly DateTime _birthDate;

        public OverEighteenRule(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public bool IsBroken() => _birthDate < DateTime.Now.AddYears(-18);

        public string Message => "Person should be over 18 years of age.";
    }
}