using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Auths.Commands.Login
{
    public class LoginCommand : CommandBase<ReturnLoginViewModel>
    {
        public string PersonalNumber { get; set; }
        public string Password { get; set; }

        public LoginCommand(string personalNumber, string password)
        {
            PersonalNumber = personalNumber;
            Password = password;
        }
    }
}