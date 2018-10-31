using Solution.Domain.Domains;
using Solution.Model.Models;
using System;
using System.Collections.Generic;

namespace Solution.Application.Applications
{
    public sealed class FileApplication : IFileApplication
    {
        public FileApplication(IFileDomain fileDomain)
        {
            FileDomain = fileDomain;
        }

        private IFileDomain FileDomain { get; }

        public IEnumerable<FileModel> Save(string directory, IEnumerable<FileModel> files)
        {
            return FileDomain.Save(directory, files);
        }

        public FileModel Select(string directory, Guid id)
        {
            return FileDomain.Select(directory, id);
        }
    }
}
