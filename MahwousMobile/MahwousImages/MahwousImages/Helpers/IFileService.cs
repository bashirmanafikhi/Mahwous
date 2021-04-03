using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MahwousImages.Helpers
{
    public interface IFileService
    {
        void SaveImage(Stream data, string name, string location = "صور");
        Task<bool> SaveImage(byte[] data, string name, string location = "صور");
    }
}
