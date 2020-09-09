using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tolentinos.Domain.Interfaces
{
    public interface IFileUploadHandler
    {
        string SaveFile(IFormFile file, string savePath);

        bool DeleteFile(string path);

    }
}
