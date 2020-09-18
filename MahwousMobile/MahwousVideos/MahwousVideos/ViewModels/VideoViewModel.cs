using MahwousVideos.Models;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MahwousVideos.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        readonly VideoStatus video;

        public VideoStatus Video => video;

        public VideoViewModel(VideoStatus video)
        {
            this.video = video;
        }

    }
}
