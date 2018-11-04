using System;
using System.Security.Cryptography;
using System.Text;

namespace Solution.CrossCutting.Security
{
    public class Hash : IHash
    {
        public string Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(value);
            }

            using (var algorithm = new SHA512Managed())
            {
                var bytes = algorithm.ComputeHash(Encoding.Unicode.GetBytes(value));
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }
    }
}
