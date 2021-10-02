using Mahwous.Core.Enums;
using System.IO;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFile(byte[] file, FileType fileType);
        Task<string> SaveFile(MemoryStream file, FileType fileType);

        Task<string> EditFile(string fileRoute, byte[] newFile, FileType fileType);
        Task<string> EditFile(string fileRoute, MemoryStream newFile, FileType fileType);

        byte[] GetFile(string fileRoute);

        Task DeleteFile(string fileRoute);
    }
}
