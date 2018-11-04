using System;

namespace Solution.CrossCutting.Utils.Objects
{
    public class FileBinary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Bytes { get; set; }

        public string ContentType { get; set; }

        public long Length { get; set; }
    }
}
