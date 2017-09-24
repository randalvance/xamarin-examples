using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GettingStartedApp001
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var stackLayout = new StackLayout() { VerticalOptions = LayoutOptions.Center };
            var label = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Welcome to Xamarin Forms!"
            };
            var button = new Button()
            {
                Text = "Click Me"
            };
            button.Clicked += async (s, e) =>
            {
                await MainPage.DisplayAlert("Alert", "You clicked me", "OK");
            }; ;

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(button);

            MainPage = new ContentPage
            {
                Content = stackLayout
            };
        }
    }
}
