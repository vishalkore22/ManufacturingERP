using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class ImageUploadViewModel
    {
        public IFormFile Imagefile { get; set; }
        public string FileName { get; set; }
    }
}
