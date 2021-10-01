using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            try
            {
                InitializeComponent();
                var vm = (AccountsViewModel)BindingContext;
                vm.LoggedSuccessfully += () =>
                {
                    Application.Current.MainPage = Settings.MainShellWindow;
                };
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }

            /*
             var vm = new AccountsViewModel();
            this.BindingContext = vm;
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.LoginCommand.Execute(null);
            };
             * */
        }
        private async void GoToRegisterPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());

        }
    }
}