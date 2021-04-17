using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Work;
using MahwousMobile.Base.Helpers;

namespace MahwousImages.Droid
{
    public class NotificationWorker : Worker
    {
        public NotificationWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {

        }

        public override Result DoWork()
        {


            NotificationWorkerHelper workerHelper = new NotificationWorkerHelper();
            workerHelper.CheckNotification().Wait();


            Android.Util.Log.Debug("NotificationWorker", $"NotificationWorker worked");

            return Result.InvokeSuccess();


        }



        public double CalculateTaxes()
        {
            return 2000;
        }
    }

}