using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace registrationapp_services.Utils
{
    public class CryptoHelper : ICryptoHelper
    {
        private string Key { get; }

        public CryptoHelper(IOptions<CryptoOptions> options)
        {
            Key = options.Value.Key;
        }

        public string EncryptString(string text)
        {
            var iv = new byte[16];
            byte[] array;

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
    }
}
