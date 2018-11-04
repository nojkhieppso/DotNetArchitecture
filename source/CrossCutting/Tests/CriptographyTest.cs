using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;
using System;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class CriptographyTest
    {
        public CriptographyTest()
        {
            Criptography = new Criptography(Guid.NewGuid().ToString());
        }

        private ICriptography Criptography { get; }

        [TestMethod]
        public void CriptographyEncryptDecrypt()
        {
            const string text = nameof(Criptography);
            var encrypted = Criptography.Encrypt(text);
            var decrypted = Criptography.Decrypt(encrypted);

            Assert.AreEqual(text, decrypted);
        }
    }
}
