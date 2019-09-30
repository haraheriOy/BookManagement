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
            set_DB_BOOK_MASTER();
            set_DB_USER_MASTER();
            IEnumerable<Models.DB_USER_MASTER> data = _db.Query<Models.DB_USER_MASTER>("SELECT * FROM DB_USER_MASTER");
            // レンタル履歴のリフレッシュ
            _db.DropTable<DB_RENTAL_LIST>();
            _db.CreateTable<DB_RENTAL_LIST>();
        }

        public IEnumerable<DB_USER_MASTER> GetItems() { 
            lock(Locker){
                // Delete==falseの一覧を取得する（削除フラグが立っているものは対象外）
                return _db.Table<DB_USER_MASTER>().Where(m => m.USER_ID == 1);
            }
        }

        // USER_MASTERテーブルの更新処理
        public int Update_DB_USER_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Update(item);
            }
        }
        
        // USER_MASTERテーブルの追加処理
        public int Insert_DB_USER_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Insert(item);
            }
        }

        // BOOK_MASTERテーブルの更新処理
        public int Update_DB_BOOK_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Update(item);
            }
        }

        // BOOK_MASTERテーブルの追加処理
        public int Insert_DB_BOOK_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Insert(item);
            }
        }

        // RENTAL_MASTERテーブルの更新処理
        public int Update_RENTAL_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Update(item);
            }
        }

        // RENTAL_MASTERテーブルの追加処理
        public int Insert_RENTAL_MASTER(DB_USER_MASTER item)
        {
            lock (Locker)
            {
                return _db.Insert(item);
            }
        }

        // USER_MASTERテーブル内をUSER_NAMEから検索
        public IEnumerable<Models.DB_USER_MASTER> ExeSql(string sql)
        {
            return _db.Query<Models.DB_USER_MASTER>(sql);
        }

        // USER_MASTERテーブル内をUSER_NAMEから検索
        public IEnumerable<Models.DB_USER_MASTER> ExeSql(string sql, string userName)
        {
            return _db.Query<Models.DB_USER_MASTER>(sql,userName);
        }

        private void set_DB_USER_MASTER()
        {
            _db.DropTable<DB_USER_MASTER>();
            _db.CreateTable<DB_USER_MASTER>();
            var item = new DB_USER_MASTER();
            item.USER_ID = 1;
            item.PASSWORD = "pass";
            item.USER_NAME = "user";
            item.ROLE = "ADMIN";
            item.IC_DATA = "test";
            _db.Insert(item);
        }

        private void set_DB_BOOK_MASTER()
        {
            _db.DropTable<DB_BOOK_MASTER>();
            _db.CreateTable<DB_BOOK_MASTER>();
            var item = new DB_BOOK_MASTER();

            DateTime arrivalYmd = DateTime.Now;
            item.BOOK_ID = 1111;
            item.TITLE = "TEST";
            item.AUTHOR = "test";
            item.PUBISHER = "test社";
            item.CATEGORY_ID = 1;
            item.ARRIBAL_YMD = arrivalYmd;
            item.DISPOSAL_FLG = false;
            _db.Insert(item);
        }
    }
}
