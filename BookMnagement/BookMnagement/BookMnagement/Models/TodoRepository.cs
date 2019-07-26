using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace BookMnagement.Models
{
    class TodoRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public TodoRepository()
        {
            _db = DependencyService.Get<Models.ISQLite>().GetConnection();
            _db.DropTable<SQLiteItem>();
            _db.CreateTable<SQLiteItem>();
            var item = new SQLiteItem();
            item.UserName = "user";
            item.Password = "5kaime";
            _db.Insert(item);
        }

        public IEnumerable<SQLiteItem> GetItems() { 
            lock(Locker){
                // Delete==falseの一覧を取得する（削除フラグが立っているものは対象外）
                return _db.Table<SQLiteItem>().Where(m => m.Delete == false);
            }
        }
        public int SaveItem(SQLiteItem item)
        {
            lock (Locker)
            {
                if(item.Id != 0)
                {
                    _db.Update(item);
                    return item.Id;
                }
                return _db.Insert(item);
            }
        }
        
        // sqlの実行
        public IEnumerable<Models.SQLiteItem> ExeSql(string sql, string userName)
        {
            return _db.Query<Models.SQLiteItem>(sql,userName);
        }
    }
}
