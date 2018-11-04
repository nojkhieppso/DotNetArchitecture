using Solution.CrossCutting.Utils.Objects;
using System;
using System.Collections.Generic;

namespace Solution.Application.Applications
{
    public interface IFileApplication
    {
        IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files);

        FileBinary Select(string directory, Guid id);
    }
}
