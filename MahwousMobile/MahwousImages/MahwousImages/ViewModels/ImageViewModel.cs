﻿using MahwousMobile.Base.Helpers;
using MahwousImages.Helpers;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousImages.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {
        readonly ImageStatus image;

        public ImageStatus Image => image;

        public ImageViewModel(ImageStatus image)
        {
            this.image = image;
            DownloadImageCommand = new Command(async () => await ExecuteDownloadImageCommand());
            ShareImageCommand = new Command(async () => await ExecuteShareImageCommand());
            ToggleLikeCommand = new Command(async () => await ExecuteToggleLikeCommand());

            MahwousSqliteDB<ImageStatus> database = new MahwousSqliteDB<ImageStatus>();
            Liked = database.Exists(image);
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
                return Image?.LikesCount ?? 0;
            }
            set
            {
                Image.LikesCount = value;
                OnPropertyChanged(nameof(Image.LikesCount));
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
                    await Repositories.ImagesRepository.DecrementLikes(image.Id);

                    using (MahwousSqliteDB<ImageStatus> database = new MahwousSqliteDB<ImageStatus>())
                    {
                        database.Remove(Image);
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
                    await Repositories.ImagesRepository.IncrementLikes(image.Id);

                    using (MahwousSqliteDB<ImageStatus> database = new MahwousSqliteDB<ImageStatus>())
                    {
                        database.Add(Image);
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




        public Command DownloadImageCommand { get; set; }
        public Command ShareImageCommand { get; set; }

        async Task ExecuteDownloadImageCommand()
        {
            IsBusy = true;

            try
            {
                DependencyService.Get<IMessage>().LongAlert("جاري تحميل الصورة");

                byte[] fileByteArray = await Repositories.ImagesRepository.Download(image.Id);

                bool result =  await DependencyService.Get<IFileService>().SaveImage(fileByteArray, "image_" + image.Id);
                if (result)
                {
                    //DependencyService.Get<IMessage>().ShortAlert("تم تحميل الصورة بنجاح");

                    var notification = new NotificationRequest
                    {
                        NotificationId = image.Id,
                        Title = "تم تحميل الصورة بنجاح",
                        Description = "صورة من موقع مهووس",
                        ReturningData = "Dummy data", // Returning data when tapped on notification.
                    };
                    NotificationCenter.Current.Show(notification);




                    await Repositories.ImagesRepository.IncrementDownloads(image.Id);


                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("حصل خطء أثناء تحميل الصورة");
                }
            }
            catch (Exception)
            {
                DependencyService.Get<IMessage>().ShortAlert("حصل خطء أثناء تحميل الصورة");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteShareImageCommand()
        {
            IsBusy = true;

            try
            {
                DependencyService.Get<IMessage>().ShortAlert("جاري تحميل الصورة للمشاركة");


                byte[] fileByteArray = await Repositories.ImagesRepository.Download(image.Id);

                string path = Path.Combine(FileSystem.CacheDirectory, "image.jpg");
                
                File.WriteAllBytes(path, fileByteArray);
                
                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "مشاركة صورة مهووس",
                    File = new ShareFile(path)
                });

                await Repositories.ImagesRepository.IncrementShares(image.Id);
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