using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using MahwousMobile.Base.ViewModels;
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