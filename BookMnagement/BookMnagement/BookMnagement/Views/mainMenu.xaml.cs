using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMnagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainMenu : ContentPage
    {
        public mainMenu(List<Models.SQLiteItem> userdata)
        {
            InitializeComponent();
            label1.Text = userdata[0].UserName;
            label2.Text = userdata[0].Password;
        }
        async void OnLendButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookList());
        }
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}