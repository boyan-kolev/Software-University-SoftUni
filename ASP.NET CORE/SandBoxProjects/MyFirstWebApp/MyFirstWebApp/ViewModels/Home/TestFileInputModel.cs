using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels.Home
{
    public class FileUploadInputModel
    {
        public IFormFile someFile { get; set; }
    }
}
