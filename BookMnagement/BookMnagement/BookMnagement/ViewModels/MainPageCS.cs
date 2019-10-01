using System;
using Xamarin.Forms;

namespace BookMnagement.ViewModels
{
	public class MainPageCS : ContentPage
	{
		public MainPageCS ()
		{
			var toolbarItem = new ToolbarItem {
				Text = "Logout"
			};
			toolbarItem.Clicked += OnLogoutButtonClicked;
			ToolbarItems.Add (toolbarItem);
            var lendingButtton = new Button { Text = "Lending"  };
            lendingButtton.Clicked += OnLendingButtonClicked;

            Title = "Main Page";
            StackLayout Content = new StackLayout { 
				Children = {
                    lendingButtton
					/*new Label {
						Text = "Main app content goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}*/
				}
			};
		}

        public void OnLendingButtonClicked(object sender, EventArgs e)
        {
            
        }

        async void OnLogoutButtonClicked (object sender, EventArgs e)
		{
			App.IsUserLoggedIn = false;
			Navigation.InsertPageBefore (new LoginPageCS (), this);
			await Navigation.PopAsync ();
		}
	}
}
