using Solution.CrossCutting.Utils.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution.Domain.Domains
{
    public sealed class FileDomain : IFileDomain
    {
        public IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files)
        {
            Directory.CreateDirectory(directory);

            foreach (var file in files)
            {
                var fileName = string.Concat(file.Id, Path.GetExtension(file.Name));

                var filePath = Path.Combine(directory, fileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    fs.Write(file.Bytes);
                }

                file.Bytes = null;
            }

            return files;
        }

        public FileBinary Select(string directory, Guid id)
        {
            var directoryInfo = new DirectoryInfo(directory);

            var fileInfo = directoryInfo.GetFiles("*" + id + "*.*").SingleOrDefault();

            if (fileInfo == null)
            {
                return null;
            }

            return new FileBinary
            {
                Bytes = File.ReadAllBytes(fileInfo.FullName),
                Name = fileInfo.Name,
                Length = fileInfo.Length
            };
        }
    }
}
