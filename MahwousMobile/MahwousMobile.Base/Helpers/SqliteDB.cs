using MahwousWeb.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MahwousMobile.Base.Helpers
{
    public class MahwousSqliteDB<T> : IDisposable where T : ModelBase , new()
    {

        const string dbFileName = "Mahwous.db3";
        public SQLiteConnection Connection { get; set; }

        public MahwousSqliteDB()
        {
            initialize();
        }

        string DatabasePath
        {
            get
            {
                string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(baseFolder, dbFileName);
            }
        }

        void initialize()
        {
            Connection = new SQLiteConnection(DatabasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            Connection.CreateTable<T>(CreateFlags.None);
        }

        public void Dispose()
        {
            Connection.Close();
        }


        public List<T> ReadAll()
        {
            return Connection.Table<T>().ToList();
        }

        public int Add(T obj)
        {
            if (!Exists(obj))
            {
                return Connection.Insert(obj);
            }
            return 0;
        }

        public int Remove(T obj)
        {
            return Connection.Table<T>().Delete(q => q.Id == obj.Id);
        }

        public bool Exists(T obj)
        {
            return Connection.Table<T>().Any(q => q.Id == obj.Id);
        }
    }
}
