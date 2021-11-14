using Mahwous.Core.Enums;
using MahwousMobile.Base.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{
    [DesignTimeVisible(false)]
    public partial class ExternalLinksPage : ContentPage
    {
        ExternalLinksViewModel viewModel;

        public ExternalLinkType LinkType
        {
            set
            {
                if (viewModel != null)
                    viewModel.ExternalLinkFilter.LinkType = value;
            }
        }

        public ExternalLinksPage()
        {
            InitializeComponent();

            this.viewModel = (BindingContext as ExternalLinksViewModel);
        }

        protected override void OnAppearing()
        {
            if (viewModel.ExternalLinks.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}