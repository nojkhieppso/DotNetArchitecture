using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.CrossCutting.AspNetCore.Extensions;
using Solution.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class FilesController : ControllerBase
    {
        public FilesController(IHostingEnvironment environment, IFileApplication fileApplication)
        {
            Environment = environment;
            FileApplication = fileApplication;
            Directory = Path.Combine(Environment.ContentRootPath, "Files");
        }

        private string Directory { get; }

        private IHostingEnvironment Environment { get; }

        private IFileApplication FileApplication { get; }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var file = FileApplication.Select(Directory, id);

            new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out var contentType);

            return File(file.Bytes, contentType, file.Name);
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public IEnumerable<FileModel> Post()
        {
            return FileApplication.Save(Directory, Request.Files());
        }
    }
}
