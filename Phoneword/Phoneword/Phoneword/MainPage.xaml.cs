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

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(_entry);
            stackLayout.Children.Add(_translateButton);
            stackLayout.Children.Add(_callButton);

            Content = stackLayout;
		}

        private void TranslateButtonClicked(object sender, EventArgs e)
        {
            var textToTranslate = _entry.Text;

            var translated = PhonewordTranslator.ToNumber(textToTranslate);

            if (!string.IsNullOrWhiteSpace(translated))
            {
                _callButton.Text = $"Call {translated}";
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
