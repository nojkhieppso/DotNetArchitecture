using Microsoft.AspNetCore.Http;
using Solution.CrossCutting.Utils.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace Solution.CrossCutting.AspNetCore
{
    public static class HttpRequestExtensions
    {
        public static IList<FileBinary> Files(this HttpRequest request)
        {
            var files = new List<FileBinary>();

            foreach (var formFile in request.Form.Files)
            {
                var file = new FileBinary
                {
                    Id = Guid.NewGuid(),
                    ContentType = formFile.ContentType,
                    Length = formFile.Length,
                    Name = formFile.Name
                };

                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    file.Bytes = ms.ToArray();
                }

                files.Add(file);
            }

            return files;
        }
    }
}
