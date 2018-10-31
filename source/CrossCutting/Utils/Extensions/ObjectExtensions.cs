using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Solution.CrossCutting.Utils;

namespace System
{
    public static class ObjectExtensions
    {
        public static byte[] ToBytes(this object obj)
        {
            if (obj == null)
            {
                return default;
            }

            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);

                return ms.ToArray().Compress();
            }
        }
    }
}
