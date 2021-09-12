using MahwousWeb.Service.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace MahwousConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do();


            Console.ReadKey();
        }


        private static void SaveFileStream(Stream stream,String path)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }

        static async void Do()
        {
            Console.WriteLine("Do function started..");

            var mahwous = new MahwousRepositories(@"https://localhost:44333/");




            var stream1 = await mahwous.VideosRepository.Download(34);

            var stream2 = await mahwous.ImagesRepository.Download(30);

            var stream3 = await mahwous.QuotesRepository.Download(41);

            //SaveFileStream(stream1, "1.mp4");
            //SaveFileStream(stream2, "2.jpg");
            //SaveFileStream(stream3, "3.txt");


            Console.WriteLine("Done");


            Console.ReadKey();
        }
    }
}
