using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.Forms;
using BookMnagement.iOS;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace BookMnagement.iOS
{
    public class SQLite_iOS : Models.ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // <-2
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // <-3
            var path = Path.Combine(libraryPath, "TodoSQLite.db3");         // <-4
            return new SQLiteConnection(path);     // <-5
        }
    }
}