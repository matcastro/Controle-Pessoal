using System.Security.Cryptography;
using System.Text;

namespace Personal.Control.Utils.Criptography
{
    public static class PasswordEncryptor
    {
        const int keySize = 64;
        const int iterations = 350000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        /// <summary>
        /// Method that encrypts a password with a salt
        /// </summary>
        /// <param name="password">Password to be encrypted</param>
        /// <param name="salt">Salt to be added in password encryption</param>
        /// <returns>The encrypted password string</returns>
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
