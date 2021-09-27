using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MahwousWeb.API.Helpers
{
    public interface IFileStorageService
    {
        Task<string> EditFile(IFormFile content, string extension, string fileRoute);
        Task DeleteFile(string fileRoute);
        //Task<string> SaveFile(byte[] content, string extension, string containerName);
        Task<string> SaveFile(IFormFile content, string extension, string containerName);
        byte[] GetFile(string fileRoute);
    }
}
