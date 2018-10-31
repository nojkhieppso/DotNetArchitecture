using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;
using System;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class JsonWebTokenTest
    {
        public JsonWebTokenTest()
        {
            JsonWebToken = new JsonWebToken(new JsonWebTokenSettings(Guid.NewGuid().ToString()));
        }

        private IJsonWebToken JsonWebToken { get; }

        [TestMethod]
        public void JsonWebTokenEncodeDecode()
        {
            var encoded = JsonWebToken.Encode("sub", new[] { "admin" });
            var decoded = JsonWebToken.Decode(encoded);

            Assert.IsNotNull(decoded);
        }

        [TestMethod]
        public void JsonWebTokenGetTokenValidationParameters()
        {
            Assert.IsNotNull(JsonWebToken.TokenValidationParameters);
        }
    }
}
