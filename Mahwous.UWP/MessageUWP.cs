using Mahwous.UWP;
using MahwousMobile.Base.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MessageUWP))]
namespace Mahwous.UWP
{
    public class MessageUWP : IMessage
    {
        public void LongAlert(string message)
        {

        }

        public void ShortAlert(string message)
        {

        }
    }
}
