using System;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class PersonPositionRule : IBusinessRule
    {
        private readonly string _position;

        public PersonPositionRule(string position)
        {
            _position = position;
        }

        public bool IsBroken() => !Enum.IsDefined(typeof(PersonPosition), _position);

        public string Message => $"Position: {_position} doesn't exist.";
    }
}