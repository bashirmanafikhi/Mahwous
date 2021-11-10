﻿using AutoMapper;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using Plugin.LocalNotification;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        readonly VideoStatus video;

        public VideoStatus Video => video;
        public VideosViewModel VideosViewModel { get; set; }

        public VideoViewModel(Mahwous.Core.Entities.VideoStatus video)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mahwous.Core.Entities.VideoStatus, VideoStatus>();
            });

            IMapper mapper = config.CreateMapper();

            this.video = mapper.Map<VideoStatus>(video);

            DownloadVideoCommand = new Command(async () => await ExecuteDownloadVideoCommand());
            ShareVideoCommand = new Command(async () => await ExecuteShareVideoCommand());
            ToggleLikeCommand = new Command(async () => await ExecuteToggleLikeCommand());

            VideosViewModel = new VideosViewModel();

            MahwousSqliteDB<VideoStatus> database = new MahwousSqliteDB<VideoStatus>();
            Liked = database.Exists(Video);
        }




        private bool liked;
        public bool Liked
        {
            get
            {
                return liked;
            }
            set
            {
                SetProperty(ref liked, value);
            }
        }

        public int LikesCount
        {
            get
            {
                return Video?.LikesCount ?? 0;
            }
            set
            {
                Video.LikesCount = value;
                OnPropertyChanged(nameof(Video.LikesCount));
            }
        }


        public ICommand ToggleLikeCommand { get; }
        private async Task ExecuteToggleLikeCommand()
        {

            if (Liked)
            {
                try
                {
                    LikesCount--;
                    Liked = false;
                    //await Repositories.VideoStatusRepository.DecrementLikes(video.Id);

                    using (MahwousSqliteDB<VideoStatus> database = new MahwousSqliteDB<VideoStatus>())
                    {
                        database.Remove(Video);
                    }

                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().ShortAlert("آسفين، حصل خطء ولم يتم إلغاء الإعجاب");
                    LikesCount++;
                    Liked = true;
                }
            }
            else
            {
                try
                {
                    LikesCount++;
                    Liked = true;
                    //await Repositories.VideoStatusRepository.IncrementLikes(video.Id);

                    using (MahwousSqliteDB<VideoStatus> database = new MahwousSqliteDB<VideoStatus>())
                    {
                        database.Add(Video);
                    }

                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().ShortAlert("آسفين، حصل خطء ولم يتم الإعجاب");
                    LikesCount--;
                    Liked = false;
                }
            }
        }




        public Command DownloadVideoCommand { get; set; }
        public Command ShareVideoCommand { get; set; }

        async Task ExecuteDownloadVideoCommand()
        {
            IsBusy = true;

            try
            {
                DependencyService.Get<IMessage>().LongAlert("جاري تحميل الفيديو");

                byte[] fileByteArray = await Repositories.VideoStatusRepository.Download(video.Id);

                bool result = await DependencyService.Get<IFileService>().SaveVideo(fileByteArray, video.Title);
                if (result)
                {
                    //DependencyService.Get<IMessage>().ShortAlert("تم تحميل الفيديو بنجاح");

                    var notification = new NotificationRequest
                    {
                        NotificationId = video.Id,
                        Title = "تم تحميل الفيديو بنجاح",
                        Description = video.Title,
                        ReturningData = "Dummy data", // Returning data when tapped on notification.
                    };
                    NotificationCenter.Current.Show(notification);




                    //await Repositories.VideoStatusRepository.IncrementDownloads(video.Id);


                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("حصل خطء أثناء تحميل الفيديو");
                }
            }
            catch (Exception)
            {
                DependencyService.Get<IMessage>().ShortAlert("حصل خطء أثناء تحميل الفيديو");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteShareVideoCommand()
        {
            IsBusy = true;

            try
            {
                DependencyService.Get<IMessage>().ShortAlert("جاري تحميل الفيديو للمشاركة");


                byte[] fileByteArray = await Repositories.VideoStatusRepository.Download(video.Id);

                string path = Path.Combine(FileSystem.CacheDirectory, "video.mp4");

                File.WriteAllBytes(path, fileByteArray);

                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "مشاركة فيديو مهووس",
                    File = new ShareFile(path)
                });

                //await Repositories.VideoStatusRepository.IncrementDownloads(video.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
