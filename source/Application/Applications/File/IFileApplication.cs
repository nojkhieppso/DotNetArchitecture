using Solution.Model.Models;
using System;
using System.Collections.Generic;

namespace Solution.Application.Applications
{
    public interface IFileApplication
    {
        IEnumerable<FileModel> Save(string directory, IEnumerable<FileModel> files);

        FileModel Select(string directory, Guid id);
    }
}
