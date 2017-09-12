using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private EditText inputBill;
        private Button calculateButton;
        private TextView outputTip;
        private TextView outputTotal;

        private string amountOfBill;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += CalculateButtonClicked;
        }

        private void CalculateButtonClicked(object sender, System.EventArgs e)
        {
            amountOfBill = inputBill.Text;

            double amount = double.Parse(amountOfBill);
            double tip = amount * 0.15;
            double total = amount + tip;

            outputTip.Text = tip.ToString();
            outputTotal.Text = total.ToString();
        }
    }
}

