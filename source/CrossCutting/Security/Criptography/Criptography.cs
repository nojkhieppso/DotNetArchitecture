using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Solution.CrossCutting.Security
{
    public class Criptography : ICriptography
    {
        public Criptography(string key)
        {
            Key = key;
        }

        private string Key { get; }

        public string Decrypt(string value)
        {
            return Encoding.Unicode.GetString(Transform(Convert.FromBase64String(value), Algorithm().CreateDecryptor()));
        }

        public string Encrypt(string value)
        {
            return Convert.ToBase64String(Transform(Encoding.Unicode.GetBytes(value), Algorithm().CreateEncryptor()));
        }

        private static byte[] Transform(byte[] bytes, ICryptoTransform cryptoTransform)
        {
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.Close();
            return ms.ToArray();
        }

        private SymmetricAlgorithm Algorithm()
        {
            var key = new Rfc2898DeriveBytes(Key, Encoding.ASCII.GetBytes(Key));
            var algorithm = new RijndaelManaged();
            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);
            return algorithm;
        }
    }
}
