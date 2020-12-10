using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Widget;
using MahwousVideos.Droid;
using MahwousVideos.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace MahwousVideos.Droid
{
    public class FileService : IFileService
    {
        public void SaveImage(System.IO.Stream data, string name, string location = "temp")
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "مهووس", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }
        }

        public async Task<bool> SaveVideo(byte[] file, string name, string location = "فيديوهات مهووس")
         {
            try
            {
                // permissions
                await Permissions.RequestAsync<ReadWriteStoragePermission>();

                // save video
                var directoryPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

                directoryPath = Path.Combine(directoryPath, "مهووس", location);

                Directory.CreateDirectory(directoryPath);

                string filePath = Path.Combine(directoryPath, name + ".mp4");

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    fs.Write(file, 0, file.Length);
                }

                // media scanning
                MediaScannerConnection.ScanFile(
                    Android.App.Application.Context,
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
                (Android.Manifest.Permission.ReadExternalStorage, true),
                (Android.Manifest.Permission.WriteExternalStorage, true)
            }.ToArray();
        }

    }
}