using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
	public partial class MainPage : ContentPage
	{
        private Entry _entry;
        private Button _translateButton;
        private Button _callButton;

        private string _translatedNumber;

		public MainPage()
		{
            var stackLayout = new StackLayout()
            {
                Spacing = 15
            };

            var label = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Enter a Phoneword:"
            };

            _entry = new Entry()
            {
                Text = "1 - 855 - XAMARIN"
            };

            _translateButton = new Button()
            {
                Text = "Translate"
            };

            _translateButton.Clicked += TranslateButtonClicked;

            _callButton = new Button()
            {
                Text = "Call",
                IsEnabled = false
            };

            _callButton.Clicked += CallButtonClicked;

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(_entry);
            stackLayout.Children.Add(_translateButton);
            stackLayout.Children.Add(_callButton);

            Content = stackLayout;
		}

        private async void CallButtonClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirm Call", "Do you want to call this number?", "Yes", "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                await dialer.DialAsync(_translatedNumber);
            }
        }

        private void TranslateButtonClicked(object sender, EventArgs e)
        {
            var textToTranslate = _entry.Text;

            _translatedNumber = PhonewordTranslator.ToNumber(textToTranslate);

            if (!string.IsNullOrWhiteSpace(_translatedNumber))
            {
                _callButton.Text = $"Call {_translatedNumber}";
                _callButton.IsEnabled = true;
            }
            else
            {
                _callButton.Text = "Call";
                _callButton.IsEnabled = false;
            }

        }
    }
}
