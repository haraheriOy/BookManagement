using System;
using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace BookMnagement.Views
{
	public partial class LoginPage : ContentPage
	{
        readonly Models.TodoRepository _db = new Models.TodoRepository();
		public LoginPage ()
		{
			InitializeComponent ();
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new BookMnagement.Views.SignUpPage());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
            var user = new BookMnagement.Models.User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };
            string sql = "select * from SQLiteItem where UserName = ?";
            //IEnumerable < Models.SQLiteItem > data = _db.ExeSql(sql, user.Username);
            List<Models.SQLiteItem> data = _db.ExeSql(sql, user.Username);
            App.userData = data;
            if (data.Count() == 0)
            {
                messageLabel.Text = "not data";
                passwordEntry.Text = string.Empty;
            }
            else
            {
                foreach (Models.SQLiteItem userdata in data)
                {
                    if (userdata.Password.Equals(user.Password))
                    {
                        App.IsUserLoggedIn = true;
                        Navigation.InsertPageBefore(new mainMenu(data), this);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        messageLabel.Text = "not data";
                        passwordEntry.Text = string.Empty;
                    }
                }
            }
            
            /* 
            var isValid = AreCredentialsCorrect (user);
			if (isValid) {
				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore (new MainPage (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
            */
		}

		bool AreCredentialsCorrect (BookMnagement.Models.User user)
		{
			return user.Username == BookMnagement.Models.Constants.Username && user.Password == BookMnagement.Models.Constants.Password;
		}
	}
}
