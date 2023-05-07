using System.Security.Cryptography;
using System.Text;

namespace Personal.Control.Utils.Criptography
{
    public static class PasswordEncryptor
    {
        const int keySize = 64;
        const int iterations = 350000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string Encrypt(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
