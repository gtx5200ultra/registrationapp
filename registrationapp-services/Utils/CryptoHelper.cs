using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace registrationapp_services.Utils
{
    public class CryptoHelper : ICryptoHelper
    {
        private readonly CryptoOptions _options;

        public CryptoHelper(IOptions<CryptoOptions> options)
        {
            _options = options.Value;
        }

        public string EncryptString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var salt = GetSalt();
            var pbkdf2 = new Rfc2898DeriveBytes(text, salt, _options.Iterations, HashAlgorithmName.SHA1);
            var bHash = pbkdf2.GetBytes(_options.HashSize);

            var saltAndHash = new byte[_options.SaltSize + _options.HashSize];

            Array.Copy(salt, 0, saltAndHash, 0, _options.SaltSize);
            Array.Copy(bHash, 0, saltAndHash, _options.SaltSize, _options.HashSize);

            var hash = Convert.ToBase64String(saltAndHash);

            return hash;
        }

        /// <summary>
        /// We do not use this implementation, but I decided to provide 'Compare' function
        /// </summary>
        public bool Compare(string plaintext, string hash)
        {
            if (string.IsNullOrEmpty(plaintext))
            {
                throw new ArgumentNullException(nameof(plaintext));
            }

            if (string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException(nameof(hash));
            }

            var saltAndHash = Convert.FromBase64String(hash);
            var extractedSalt = ExtractSalt(saltAndHash);

            var pbkdf2 = new Rfc2898DeriveBytes(plaintext, extractedSalt, _options.Iterations, HashAlgorithmName.SHA1);
            var newHash = pbkdf2.GetBytes(_options.HashSize);

            for (var i = 0; i < _options.HashSize; i++)
            {
                if (saltAndHash[i + _options.SaltSize] != newHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private byte[] GetSalt()
        {
            return RandomNumberGenerator.GetBytes(_options.SaltSize);
        }

        private byte[] ExtractSalt(byte[] saltAndHash)
        {
            var extractedSalt = new byte[_options.SaltSize];

            Array.Copy(saltAndHash, 0, extractedSalt, 0, _options.SaltSize);
            return extractedSalt;
        }
    }
}
