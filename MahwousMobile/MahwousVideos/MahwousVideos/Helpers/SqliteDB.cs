//using MahwousWeb.Shared.Models;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace MahwousVideos.Helpers
//{
//    public class DbConstants
//    {
//        static string dbFileName = "Mahwous.db3";
//        public static string DatabasePath
//        {
//            get
//            {
//                string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//                return Path.Combine(baseFolder, dbFileName);
//            }
//        }
//    }

//    public class VideosDatabase : IDisposable
//    {
//        public SQLiteConnection Connection { get; set; }
//        public VideosDatabase()
//        {
//            initialize();
//        }

//        void initialize()
//        {
//            Connection = new SQLiteConnection(DbConstants.DatabasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

//            Connection.CreateTable<VideoStatus>(CreateFlags.None);
//        }

//        public void Dispose()
//        {
//            Connection.Close();
//        }


//        public List<VideoStatus> ReadAllVideos()
//        {
//            return Connection.Table<VideoStatus>().ToList();
//        }

//        public int AddVideo(VideoStatus Video)
//        {
//            if (!Exists(Video))
//            {
//                return Connection.Insert(Video);
//            }
//            return 0;
//        }

//        public int RemoveVideo(VideoStatus Video)
//        {
//            return Connection.Table<VideoStatus>().Delete(q => q.Id == Video.Id);
//        }

//        public bool Exists(VideoStatus Video)
//        {
//            return Connection.Table<VideoStatus>().Any(q => q.Id == Video.Id);
//        }
//    }
//}
