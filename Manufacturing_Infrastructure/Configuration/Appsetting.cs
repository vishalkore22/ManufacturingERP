using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Configuration
{
    public class Appsettings
    {
        public string FileName { get; set; }

        public string FileUploadPath { get; set; }

        public static class FileUpload
        {
            public static string FileName { get; set; }

            public static string FileUploadPath { get; set; }
        }
    }

    
}
