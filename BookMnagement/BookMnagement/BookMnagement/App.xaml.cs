using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookMnagement.Services;
using BookMnagement.Views;
using System.Collections.Generic;

namespace BookMnagement
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static List<Models.SQLiteItem> userData{get; set;}
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            // MainPage = new MainPage();
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                // MainPage = new NavigationPage(new BookMnagement.Views.MainPage());
                MainPage = new NavigationPage(new mainMenu(userData));
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
