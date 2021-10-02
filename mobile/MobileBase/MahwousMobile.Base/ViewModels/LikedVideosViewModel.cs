﻿using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    class LikedVideosViewModel : BaseViewModel
    {
        public ObservableCollection<VideoStatus> Videos { get; set; }

        public Command LoadVideosCommand { get; set; }

        public LikedVideosViewModel()
        {
            Videos = new ObservableCollection<VideoStatus>();
            LoadVideosCommand = new Command(() => ExecuteLoadVideosCommand());
        }

        private void ExecuteLoadVideosCommand()
        {
            IsBusy = true;
            Videos.Clear();
            try
            {
                MahwousSqliteDB<VideoStatus> database = new MahwousSqliteDB<VideoStatus>();

                var videos = database.ReadAll();
                foreach (var video in videos)
                {
                    Videos.Add(video);
                }
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