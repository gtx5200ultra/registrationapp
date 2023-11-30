using Microsoft.Extensions.Options;
using registrationapp_services.Utils;

namespace registrationapp_api_tests.UnitTests
{
    [TestClass]
    public class CryptoHelperTests
    {
        [TestMethod]
        public void CryptoHelper_CompareValid()
        {
            var crypto = new CryptoHelper(new OptionsWrapper<CryptoOptions>(new CryptoOptions
            {
                Iterations = 1000,
                SaltSize = 64,
                HashSize = 128
            }));

            var originalString = Guid.NewGuid().ToString();
            var encryptedStringHash = crypto.EncryptString(originalString);
            var compareResult = crypto.Compare(originalString, encryptedStringHash);

            Assert.IsTrue(compareResult);
        }
    }
}
