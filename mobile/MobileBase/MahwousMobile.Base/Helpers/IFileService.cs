using System.IO;
using System.Threading.Tasks;

namespace MahwousMobile.Base.Helpers
{
    public interface IFileService
    {
        void SaveImage(Stream data, string name, string location = "صور");
        Task<bool> SaveImage(byte[] data, string name, string location = "صور");
        Task<bool> SaveVideo(byte[] data, string name, string location = "فيديو");
    }
}
