using Solution.Model.Models;
using System;
using System.Collections.Generic;

namespace Solution.Domain.Domains
{
    public interface IFileDomain
    {
        IEnumerable<FileModel> Save(string directory, IEnumerable<FileModel> files);

        FileModel Select(string directory, Guid id);
    }
}
