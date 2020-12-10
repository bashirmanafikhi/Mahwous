using System.Threading.Tasks;

namespace MahwousWeb.Server.Helpers
{
    public interface IFileStorageService
    {
        Task<string> EditFile(byte[] content, string extension, string fileRoute);
        Task DeleteFile(string fileRoute);
        Task<string> SaveFile(byte[] content, string extension, string containerName);
        byte[] GetFile(string fileRoute);
    }
}
