using System;
using System.Linq;
using System.Security.Cryptography;
using PlainClasses.Infrastructure.Utils;

namespace PlainClasses.Infrastructure.Auths
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(password, Consts.SaltSize, Consts.Iterations, HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algorithm.GetBytes(Consts.KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{ Consts.Iterations }.{ salt }.{ key }";
        }

        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                //throw new BusinessException(ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(Consts.KeySize);
            var verified = keyToCheck.SequenceEqual(key);

            return verified;
        }
    }
}