using Mahwous.Core.Enums;
using Mahwous.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Mahwous.FileStorageServices
{
    public class InAppStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;
        private string wwwroot => env.WebRootPath;
        private string currentUrl => $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

        public InAppStorageService(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }


        private string GetContainerName(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Video:
                    return "videos";
                case FileType.Image:
                    return "images";
                default:
                    return "other";
            }
        }
        private string GetNewFileName(FileType fileType)
        {
            var fileName = Guid.NewGuid().ToString();
            switch (fileType)
            {
                case FileType.Video:
                    fileName += ".mp4";
                    break;
                case FileType.Image:
                    fileName += ".jpg";
                    break;
                default:
                    break;
            }

            return fileName;
        }


        public async Task DeleteFile(string fileRoute)
        {
            var fileName = Path.GetFileName(fileRoute);
            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));
            string fileDirectory = Path.Combine(wwwroot, "content", containerName, fileName);
            if (File.Exists(fileDirectory))
            {
                File.Delete(fileDirectory);
            }
        }

        public byte[] GetFile(string fileRoute)
        {
            var fileName = Path.GetFileName(fileRoute);
            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));

            string filePath = Path.Combine(wwwroot, "content", containerName, fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }

        public async Task<string> SaveFile(byte[] file, FileType fileType)
        {
            var ms = new MemoryStream(file);
            return await SaveFile(ms, fileType);
        }

        public async Task<string> SaveFile(MemoryStream file, FileType fileType)
        {
            // Get file info
            string fileName = GetNewFileName(fileType);
            string folderName = GetContainerName(fileType);

            string folderPath = Path.Combine(wwwroot, "content", folderName);
            string filePath = Path.Combine(folderPath, fileName);

            // Insure directory is exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the file
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Generate URL for the file
            Uri baseUri = new Uri(currentUrl);
            Uri myUri = new Uri(baseUri, $"content/{folderName}/{fileName}");

            var pathForDatabase = myUri.AbsoluteUri;
            return pathForDatabase;
        }

        public async Task<string> EditFile(string fileRoute, MemoryStream newFile, FileType fileType)
        {
            if (!string.IsNullOrEmpty(fileRoute))
                await DeleteFile(fileRoute);

            var containerName = Path.GetFileName(Path.GetDirectoryName(fileRoute));
            return await SaveFile(newFile, fileType);
        }

        public async Task<string> EditFile(string fileRoute, byte[] newFile, FileType fileType)
        {
            var ms = new MemoryStream(newFile);
            return await EditFile(fileRoute, ms, fileType);
        }
    }
}
