using Android.Content;
using Android.Net;
using Android.Telephony;
using Phoneword.Droid;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


[assembly: Dependency(typeof(Dialer))]

namespace Phoneword.Droid
{
    public class Dialer : IDialer
    {
        /// <summary>
        /// Dial the phone
        /// </summary>
        public Task<bool> DialAsync(string number)
        {
            var context = Forms.Context;
            if (context != null)
            {
                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + number));

                if (IsIntentAvailable(context, intent))
                {
                    context.StartActivity(intent);
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }

        /// <summary>
        /// Checks if an intent can be handled.
        /// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
                return true;

            TelephonyManager mgr = TelephonyManager.FromContext(context);
            return mgr.PhoneType != PhoneType.None;
        }
    }
}