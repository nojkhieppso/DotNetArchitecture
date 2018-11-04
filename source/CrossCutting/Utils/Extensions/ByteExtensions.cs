using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Solution.CrossCutting.Utils
{
    public static class ByteExtensions
    {
        public static byte[] Compress(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var stream = new BrotliStream(ms, CompressionMode.Compress))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                return ms.ToArray();
            }
        }

        public static byte[] Decompress(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var input = new MemoryStream(bytes))
                using (var stream = new BrotliStream(input, CompressionMode.Decompress))
                {
                    stream.CopyTo(ms);
                }

                return ms.ToArray();
            }
        }

        public static T ToObject<T>(this byte[] bytes)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes));
        }
    }
}
