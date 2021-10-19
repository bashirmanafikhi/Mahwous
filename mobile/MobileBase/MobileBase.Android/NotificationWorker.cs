using Android.Content;
using AndroidX.Work;
using MahwousMobile.Base.Helpers;

namespace MobileBase.Android
{
    public class NotificationWorker : Worker
    {
        public NotificationWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {

        }



        public override Result DoWork()
        {
            try
            {
                NotificationWorkerHelper workerHelper = new NotificationWorkerHelper();

                workerHelper.CheckNotification().Wait();

                global::Android.Util.Log.Debug("NotificationWorker", $"NotificationWorker worked");

                return Result.InvokeSuccess();
            }
            catch
            {
                return Result.InvokeFailure();
            }
        }



        public double CalculateTaxes()
        {
            return 2000;
        }
    }

}