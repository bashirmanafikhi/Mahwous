using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MahwousMobile.Base
{
    public class ShellBase: Shell
    {
        private bool maybe_exit = false;
        //-------------------------------------------------------------------
        protected override bool OnBackButtonPressed()
        //-------------------------------------------------------------------
        {
            if (Navigation.NavigationStack.Count > 1 || Navigation.ModalStack.Count > 1)
            {
                return base.OnBackButtonPressed();
            }

            //some more custom checks here

            if (!(Current.CurrentPage is HomePage) &&
                !(Current.CurrentPage is WelcomeScreenPage) &&
                !(Current.CurrentPage is LoginPage) &&
                !(Current.CurrentPage is RegisterPage))
            {
                Current.GoToAsync($"//{nameof(HomePage)}").ConfigureAwait(false);
                return true;
            }

            if (maybe_exit)
            {
                return false; //QUIT
            }

            DependencyService.Get<IMessage>().ShortAlert("إضغط مرة أخرة للخروج من البرنامج!");
            maybe_exit = true;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                maybe_exit = false; //reset those 2 seconds

                return false;// false - Don't repeat the timer 
            });
            return true; //true - don't process BACK by system
        }
    }
}
