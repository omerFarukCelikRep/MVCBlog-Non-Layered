using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Models.DataAccess.Entities.DTOs
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string Entity { get; set; }
    }
}
