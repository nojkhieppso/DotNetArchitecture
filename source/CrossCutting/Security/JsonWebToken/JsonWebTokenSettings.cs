using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Solution.CrossCutting.Security
{
    public class JsonWebTokenSettings : IJsonWebTokenSettings
    {
        public JsonWebTokenSettings(string key)
        {
            Key = key;
        }

        public string Audience => nameof(Audience);

        public DateTime Expires => DateTime.UtcNow.AddDays(1);

        public string Issuer => nameof(Issuer);

        public string Key { get; }

        public SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);
    }
}
