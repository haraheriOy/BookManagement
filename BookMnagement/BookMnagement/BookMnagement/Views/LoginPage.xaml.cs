﻿using System;
using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;

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
            var tempUser = new BookMnagement.Models.TemporaryUser
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };
            string sql = "select * from DB_USER_MASTER where USER_NAME = ?";
            IEnumerable < Models.DB_USER_MASTER > data = _db.ExeSql(sql, tempUser.Username);
            //data.GetEnumerator();
            if (data.Equals(null))
            {
                messageLabel.Text = "not data";
                passwordEntry.Text = string.Empty;
            }
            foreach (Models.DB_USER_MASTER userdata in data)
            {
                if (userdata.PASSWORD.Equals(tempUser.Password))
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    messageLabel.Text = "not data";
                    passwordEntry.Text = string.Empty;
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

		bool AreCredentialsCorrect (BookMnagement.Models.TemporaryUser user)
		{
			return user.Username == BookMnagement.Models.Constants.Username && user.Password == BookMnagement.Models.Constants.Password;
		}
	}
}
