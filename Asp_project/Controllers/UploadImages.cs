using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;

namespace Asp_project.Controllers
{
    public class UploadImages
    {

        private readonly IWebHostEnvironment WebHostEnvironment;


        public UploadImages(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public string UploadFile(IFormFile Image, string folder)
        {
            string fileName = null;
            if (Image != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, folder);
                fileName = Guid.NewGuid().ToString() + " - " + Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public string UpdateFile(IFormFile Image, string folder)
        {
            string fileName = null;

            if (Image != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, folder);
                fileName = Guid.NewGuid().ToString() + " - " + Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    Image.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public string DeleteFile(string folder, string nameImage)
        {
            var imagem = Path.Combine(WebHostEnvironment.WebRootPath, folder, nameImage);
            if (System.IO.File.Exists(imagem))
            {
                System.IO.File.Delete(imagem);
            }

            return "";
        }
    }
}
