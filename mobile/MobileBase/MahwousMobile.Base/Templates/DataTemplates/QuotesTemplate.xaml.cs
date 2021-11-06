using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using MahwousMobile.Base.ViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesTemplate : ContentView
    {
        QuotesViewModel viewModel;
        StatusSortType sortType;
        public StatusSortType SortType
        {
            get => viewModel.SortType;
            set
            {
                if (viewModel.Quotes.Count > 0)
                {
                    return;
                }

                viewModel.SortType = value;
                viewModel.LoadQuotesCommand.Execute(null);
            }
        }

        public int QuotesCount { get => viewModel.Quotes.Count; }

        public void SetCategories(params int[] categories)
        {
            viewModel.Filter.CategoryIds = categories;
            viewModel.LoadQuotesCommand.Execute(null);
        }



        public QuotesTemplate() : this(new QuotesViewModel()) { }

        public QuotesTemplate(QuotesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}