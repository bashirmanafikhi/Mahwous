using MahwousMobile.Base.ViewModels;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesTemplate : ContentView
    {
        QuotesViewModel viewModel;
        public StatusSortType SortType
        {
            get => viewModel.Filter.SortType;
            set
            {
                if (viewModel.Quotes.Count > 0)
                {
                    return;
                }

                viewModel.Filter.SortType = value;
                viewModel.LoadQuotesCommand.Execute(null);
            }
        }

        public int QuotesCount { get => viewModel.Quotes.Count; }

        public void SetCategories(params Category[] categories)
        {
            viewModel.Filter.Categories.Clear();
            foreach (var category in categories)
            {
                viewModel.Filter.Categories.Add(category);
            }
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