using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using MahwousQuotes.Models;
using MahwousQuotes.Styles;
using MahwousWeb.Shared.Models;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuoteTemplate : ContentView
    {
        private static void quotePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (QuoteTemplate)bindable;
            control.Quote = newValue as QuoteStatus;
        }


        public static readonly BindableProperty QuoteProperty = BindableProperty.Create(
                                                         propertyName: nameof(Quote),
                                                         returnType: typeof(QuoteStatus),
                                                         declaringType: typeof(QuoteTemplate),
                                                         defaultValue: null,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: quotePropertyChanged);

        public QuoteStatus Quote
        {
            get
            {
                return viewModel.Quote;
            }
            set
            {
                viewModel.Quote = value;
            }
        }



        public bool IsControlsVisible
        {
            get
            {
                return viewModel.IsControlsVisible;
            }
            set
            {
                viewModel.IsControlsVisible = value;
            }
        }

        QuoteViewModel viewModel;

        public QuoteTemplate()
        {
            InitializeComponent();

            viewModel = BindingContext as QuoteViewModel;
        }


        private async void ShowDetails(object sender, EventArgs e)
        {
            try
            {
                var viewModel = (QuoteViewModel)BindingContext;
                var quote = viewModel.Quote;

                var previousPage = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new QuoteDetailsPage(viewModel));
                if (previousPage != null && previousPage is QuoteDetailsPage)
                    Navigation.RemovePage(previousPage);
            }
            catch (Exception) {
                DependencyService.Get<IMessage>().ShortAlert("لا يمكن مشاهدة التفاصيل من هذه الصفحة");
            }
        }
    }
}