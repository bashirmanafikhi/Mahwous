using MahwousQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedQuotesPage : ContentPage
    {
        public LikedQuotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as LikedQuotesViewModel).LoadQuotesCommand.Execute(null);
        }
    }
}