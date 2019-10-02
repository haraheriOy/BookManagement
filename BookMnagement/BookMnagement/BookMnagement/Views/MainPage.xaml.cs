using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BookMnagement.Views
{
	public partial class MainPage : ContentPage
	{
        readonly Models.TodoRepository _db = new Models.TodoRepository();
        public MainPage ()
		{
			InitializeComponent ();
		}

		async void OnLogoutButtonClicked (object sender, EventArgs e)
		{
			App.IsUserLoggedIn = false;
			Navigation.InsertPageBefore (new LoginPage (), this);
			await Navigation.PopAsync ();
		}
        public void OnLendingButtonClicked(object sender, EventArgs e)
        {
            var item = new Models.DB_BOOK_MASTER();
            setItem(item);
            _db.Update_DB_BOOK_MASTER(item);
            /*string sql = "select * from DB_BOOK_MASTER";
            IEnumerable<Models.DB_BOOK_MASTER> data = _db.ExeSqlBookM(sql);
            data = _db.ExeSqlBookM(sql);
            sql = "select * from DB_BOOK_MASTER";
            data = _db.ExeSqlBookM(sql);*/
        }

        private void setItem(Models.DB_BOOK_MASTER item)
        {
            //var item = new Models.DB_BOOK_MASTER();

            DateTime arrivalYmd = DateTime.Now;
            item.BOOK_ID = 1;
            item.TITLE = "変更";
            item.AUTHOR = "変更";
            item.PUBISHER = "変更社";
            item.CATEGORY_ID = 1;
            item.ARRIBAL_YMD = arrivalYmd;
            item.DISPOSAL_FLG = false;
        }
        public string loginUserId{ get; set; }

        public void getUser (string id)
        {
            loginUserId = id;
        }
    }
}
