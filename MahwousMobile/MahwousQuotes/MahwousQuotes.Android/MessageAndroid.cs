using Android.App;
using Android.Widget;
using MahwousQuotes.Droid;
using MahwousQuotes.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace MahwousQuotes.Droid
{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}