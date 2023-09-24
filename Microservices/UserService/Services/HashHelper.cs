using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using System.Security.Cryptography;

namespace UserService.Services
{
    public static class HashHelper
    {
        private const int _iterationsCount = 16;
        private const int _length = 32;
        private static KeyDerivationPrf _algorithm = KeyDerivationPrf.HMACSHA256;

        public static (string PasswordHash, string PasswordSalt) Encrypt(string source)
        {
            var salt = new byte[32];
            RandomNumberGenerator.Fill(salt);
            var hash = KeyDerivation.Pbkdf2(source, salt, _algorithm, _iterationsCount, _length);
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        public static string Encrypt(string source, string base64Salt)
        {
            var salt = Convert.FromBase64String(base64Salt);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(source, salt, _algorithm, _iterationsCount, _length));
        }

        public static string RandomToken()
        {
            var salt = new byte[32];
            RandomNumberGenerator.Fill(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
