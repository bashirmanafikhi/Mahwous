using Mahwous.Core.Dtos;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    class AccountsViewModel : BaseViewModel
    {
        public Action LoggedSuccessfully;

        // Welcome Screen
        public List<OnBoardItem> OnBoardList
        {
            get
            {
                return new List<OnBoardItem>
                {
                    new OnBoardItem
                    {
                        Title = "حالات فيديو",
                        Caption = "يمكنك الآن مشاهدة وتحميل أجدد حالات الفيديو القصيرة والممتعة كما يمكنكم مشاركتها على واتس اب او انستغرام او تيك توك"
                    },
                    new OnBoardItem
                    {
                        Title = "حالات الصور",
                        Caption = "يحتوي تطبيقنا على الكثير من الصور بتصنيفات كثيرة، يمكنكم تحميلها في نقرة واحدة ومشاركتها على مواقع التواصل الإجتماعي"
                    },
                    new OnBoardItem
                    {
                        Title = "الحالات الكتابية",
                        Caption = "أفضل واجمل الإقتباسات والحكم والرسائل ضمن تصنيفات متعددة يمكن قرائتها او نسخها"
                    }
                };
            }
        }

        // Properties
        public bool Logged => Settings.Token != null;


        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }


        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

        // Constructors
        public AccountsViewModel()
        {
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegister);
        }

        // Commands
        public ICommand LoginCommand { protected set; get; }
        public async void OnLogin()
        {
            try
            {
                var token = await Repositories.AccountsRepository.Login(new UserInfo
                {
                    Email = email,
                    Password = password
                });
                Settings.Token = token.Token;
                if (LoggedSuccessfully != null) LoggedSuccessfully.Invoke();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }

        public ICommand RegisterCommand { protected set; get; }
        public async void OnRegister()
        {
            try
            {
                var token = await Repositories.AccountsRepository.Register(
                    new RegisterUserInfo
                    {
                        Email = Email,
                        Password = Password,
                        ConfirmPassword = ConfirmPassword
                    });
                Settings.Token = token.Token;
                if (LoggedSuccessfully != null) LoggedSuccessfully.Invoke();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }
    }
}
