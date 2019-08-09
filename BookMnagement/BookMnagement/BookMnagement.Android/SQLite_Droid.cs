using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BookMnagement.Droid;
using BookMnagement.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace BookMnagement.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // <-1
            var path = Path.Combine(documentsPath, "TodoSQLite.db3"); // <-2
            return new SQLiteConnection(path); // <-3
        }
    }
}