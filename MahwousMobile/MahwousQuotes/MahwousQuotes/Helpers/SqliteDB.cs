using MahwousWeb.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MahwousQuotes.Helpers
{
    public class DbConstants
    {
        static string dbFileName = "Mahwous.db3";
        public static string DatabasePath
        {
            get
            {
                string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(baseFolder, dbFileName);
            }
        }
    }

    public class QuotesDatabase : IDisposable
    {
        public SQLiteConnection Connection { get; set; }
        public QuotesDatabase()
        {
            initialize();
        }

        void initialize()
        {
            Connection = new SQLiteConnection(DbConstants.DatabasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            Connection.CreateTable<QuoteStatus>(CreateFlags.None);
        }

        public void Dispose()
        {
            Connection.Close();
        }


        public List<QuoteStatus> ReadAllQuotes()
        {
            return Connection.Table<QuoteStatus>().ToList();
        }

        public int AddQuote(QuoteStatus quote)
        {
            if (!Exists(quote))
            {
                return Connection.Insert(quote);
            }
            return 0;
        }

        public int RemoveQuote(QuoteStatus quote)
        {
            return Connection.Table<QuoteStatus>().Delete(q => q.Id == quote.Id);
        }

        public bool Exists(QuoteStatus quote)
        {
            //return Connection.Table<QuoteStatus>().Where(q => q.Id == quote.Id).Count() > 0;
            return Connection.Table<QuoteStatus>().Any(q => q.Id == quote.Id);
        }
    }
}
