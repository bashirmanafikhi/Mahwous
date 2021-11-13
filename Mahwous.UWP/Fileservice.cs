using Mahwous.UWP;
using MahwousMobile.Base.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(Fileservice))]
namespace Mahwous.UWP
{
    public class Fileservice : IFileService
    {
        public void SaveImage(Stream data, string name, string location = "صور")
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveImage(byte[] data, string name, string location = "صور")
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveVideo(byte[] data, string name, string location = "فيديو")
        {
            throw new NotImplementedException();
        }
    }
}
