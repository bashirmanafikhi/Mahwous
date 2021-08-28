using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Widget;
using MahwousMobile.Base.Helpers;
using MobileBase.Android;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace MobileBase.Android
{
    public class FileService : IFileService
    {

        public async void SaveImage(System.IO.Stream data, string name, string location = "صور مهووس")
        {
            var ms = new MemoryStream();
            data.CopyTo(ms);
            await SaveImage(ms.ToArray(), name, location);
        }

        public async Task<bool> SaveImage(byte[] file, string name, string location = "صور مهووس")
        {
            try
            {
                // permissions
                await Permissions.RequestAsync<ReadWriteStoragePermission>();

                // save video
                string directoryPath = Path.Combine(Environment.ExternalStorageDirectory.AbsolutePath, Environment.DirectoryDownloads);

                directoryPath = Path.Combine(directoryPath, "مهووس", location);

                Directory.CreateDirectory(directoryPath);

                string filePath = Path.Combine(directoryPath, name + ".jpg");

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    fs.Write(file, 0, file.Length);
                }

                // media scanning
                MediaScannerConnection.ScanFile(
                    global::Android.App.Application.Context,
                    new string[] { filePath },
                    null,
                    null
                );


                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public async Task<bool> SaveVideo(byte[] file, string name, string location = "فيديوهات مهووس")
        {
            try
            {
                // permissions
                await Permissions.RequestAsync<ReadWriteStoragePermission>();

                // save video
                string directoryPath = Path.Combine(Environment.ExternalStorageDirectory.AbsolutePath, Environment.DirectoryDownloads);

                directoryPath = Path.Combine(directoryPath, "مهووس", location);

                Directory.CreateDirectory(directoryPath);

                string filePath = Path.Combine(directoryPath, name + ".mp4");

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    fs.Write(file, 0, file.Length);
                }

                // media scanning
                MediaScannerConnection.ScanFile(
                    global::Android.App.Application.Context,
                    new string[] { filePath },
                    null,
                    null
                );


                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public class ReadWriteStoragePermission : Xamarin.Essentials.Permissions.BasePlatformPermission
        {
            public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
            {
                (global::Android.Manifest.Permission.ReadExternalStorage, true),
                (global::Android.Manifest.Permission.WriteExternalStorage, true)
            }.ToArray();
        }

    }
}