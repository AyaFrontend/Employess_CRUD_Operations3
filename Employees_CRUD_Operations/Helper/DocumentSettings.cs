using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.Helper
{
    public class DocumentSettings
    {
        public static string SettingUploadFiles(IFormFile file, string FolderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            var filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return filePath;

        }

        public static void DeleteFile(string fileName, string FolderName)
        {

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);
            var filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
    }
}
