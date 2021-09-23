using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MahwousWeb.API.Helpers
{
    public class InAppStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InAppStorageService(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task DeleteFile(string fileRoute)
        {
            var fileName = Path.GetFileName(fileRoute);
            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));
            string fileDirectory = Path.Combine(env.WebRootPath, "content", containerName, fileName);
            if (File.Exists(fileDirectory))
            {
                File.Delete(fileDirectory);
            }

            return Task.FromResult(0);
        }


        public async Task<string> EditFile(IFormFile content, string extension, string fileRoute)
        {
            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));
            if (!string.IsNullOrEmpty(fileRoute))
            {
                await DeleteFile(fileRoute);
            }

            return await SaveFile(content, extension, containerName);
        }

        public async Task<string> SaveFile(IFormFile content, string extension, string containerName)
        {
            var fileName = $"{Guid.NewGuid()}.{extension}";
            string folder = Path.Combine(env.WebRootPath, "content", containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string savingPath = Path.Combine(folder, fileName);
            using (Stream fileStream = new FileStream(savingPath, FileMode.Create))
            {
                await content.CopyToAsync(fileStream);
            }

            var currentUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            Uri baseUri = new Uri(currentUrl);
            Uri myUri = new Uri(baseUri, $"content/{containerName}/{fileName}");

            var pathForDatabase = myUri.AbsoluteUri;
            return pathForDatabase;
        }

        //public async Task<string> SaveFile(byte[] content, string extension, string containerName)
        //{
        //    var fileName = $"{Guid.NewGuid()}.{extension}";
        //    string folder = Path.Combine(env.WebRootPath, "content", containerName);

        //    if (!Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);
        //    }

        //    string savingPath = Path.Combine(folder, fileName);
        //    await File.WriteAllBytesAsync(savingPath, content);

        //    var currentUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

        //    Uri baseUri = new Uri(currentUrl);
        //    Uri myUri = new Uri(baseUri, $"content/{containerName}/{fileName}");

        //    var pathForDatabase = myUri.AbsoluteUri;
        //    return pathForDatabase;
        //}

        public byte[] GetFile(string fileRoute)
        {
            var fileName = Path.GetFileName(fileRoute);
            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));

            string filePath = Path.Combine(env.WebRootPath, "content", containerName, fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }

    }
}
