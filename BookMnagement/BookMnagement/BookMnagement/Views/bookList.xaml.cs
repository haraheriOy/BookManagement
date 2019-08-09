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
    public partial class BookList : ContentPage
    {
        public BookList()
        {
            InitializeComponent();
        }
        async void OnDetailButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookList());
        }
    }
}