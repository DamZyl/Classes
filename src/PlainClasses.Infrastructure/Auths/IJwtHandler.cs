namespace PlainClasses.Infrastructure.Auths
{
    public interface IJwtHandler
    {
        string CreateToken(int userId, string fullName, string role);
    }
}