

using MahwousQuotes.Helpers;
using MahwousQuotes.Models;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousQuote.ViewModels
{
    // Todo: initialize quote count
    public class QuoteViewModel : BaseViewModel
    {
        public QuoteViewModel() : this(null) { }


        public QuoteViewModel(QuoteStatus quote = null)
        {
            ToggleLikeCommand = new Command(ExecuteToggleLikeCommand);
            CoppyQuoteCommand = new Command(ExecuteCoppyQuoteCommand);
            ShareQuoteCommand = new Command(ExecuteShareQuoteCommand);
            ShareQuoteWhatsCommand = new Command(ExecuteShareQuoteWhatsCommand);
            ShareQuoteFaceCommand = new Command(ExecuteShareQuoteFaceCommand);

            if (quote is null)
                initRandomQuote();
            else
                Quote = quote;
        }

        private async void initRandomQuote()
        {
            IsBusy = true;
            try
            {
                Quote = await Repositories.QuoteRepository.GetRandomQuote();
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



        private QuoteStatus quote;
        public QuoteStatus Quote
        {
            get
            {
                return quote;
            }
            set
            {
                SetProperty(ref quote, value);
            }
        }

        private bool isControlsVisible = true;
        public bool IsControlsVisible
        {
            get
            {
                return isControlsVisible;
            }
            set
            {
                SetProperty(ref isControlsVisible, value);
            }
        }

        private bool liked;
        public bool Liked
        {
            get
            {
                return liked;
            }
            set
            {
                SetProperty(ref liked, value);
            }
        }


        public int LikesCount
        {
            get
            {
                return Quote?.LikesCount ?? 0;
            }
            set
            {
                Quote.LikesCount = value;
                OnPropertyChanged(nameof(Quote.LikesCount));
            }
        }


        public int DownloadsCount
        {
            get
            {
                return Quote?.DownloadsCount ?? 0;
            }
            set
            {
                Quote.DownloadsCount = value;
                OnPropertyChanged(nameof(Quote.DownloadsCount));
            }
        }


        public int ViewsCount
        {
            get
            {
                return Quote?.ViewsCount ?? 0;
            }
            set
            {
                Quote.ViewsCount = value;
                OnPropertyChanged(nameof(Quote.ViewsCount));
            }
        }

        public ICommand ToggleLikeCommand { get; }
        private async void ExecuteToggleLikeCommand()
        {

            if (Liked)
            {
                try
                {
                    LikesCount--;
                    Liked = false;
                    await Repositories.QuoteRepository.DecrementLikes(quote.Id);

                    using (QuotesDatabase database = new QuotesDatabase())
                    {
                        database.RemoveQuote(Quote);
                    }

                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().ShortAlert("آسفين، حصل خطء ولم يتم إلغاء الإعجاب");
                    LikesCount++;
                    Liked = true;
                }
            }
            else
            {
                try
                {
                    LikesCount++;
                    Liked = true;
                    await Repositories.QuoteRepository.IncrementLikes(quote.Id);

                    using (QuotesDatabase database = new QuotesDatabase())
                    {
                        database.AddQuote(Quote);
                    }

                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().ShortAlert("آسفين، حصل خطء ولم يتم الإعجاب");
                    LikesCount--;
                    Liked = false;
                }
            }
        }


        public ICommand CoppyQuoteCommand { get; }
        public ICommand ShareQuoteCommand { get; }
        public ICommand ShareQuoteWhatsCommand { get; }
        public ICommand ShareQuoteFaceCommand { get; }



        private async void ExecuteCoppyQuoteCommand()
        {
            Quote.DownloadsCount++;

            await Clipboard.SetTextAsync(quote.Content);
            DependencyService.Get<IMessage>().ShortAlert("تم نسخ الحالة إلى الحافظة");
            await IncrementDownloads();
        }
        private async void ExecuteShareQuoteCommand()
        {
            Quote.DownloadsCount++;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = quote.Content,
                Title = "مشاركة حالة مهووس"
            });
            await IncrementDownloads();
        }
        private async void ExecuteShareQuoteWhatsCommand()
        {
            Quote.DownloadsCount++;
            DependencyService.Get<IMessage>().ShortAlert("مازلنا نعمل على برمجة هذا الزر");
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = quote.Content,
                Title = "مشاركة إلى واتس اب"
            });
            await IncrementDownloads();
        }
        private async void ExecuteShareQuoteFaceCommand()
        {
            Quote.DownloadsCount++;
            DependencyService.Get<IMessage>().ShortAlert("مازلنا نعمل على برمجة هذا الزر");
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = quote.Content,
                Title = "مشاركة إلى فيسبوك"
            });
            await IncrementDownloads();
        }

        private async Task IncrementDownloads()
        {
            try
            {
                await DependencyService.Get<Repositories>().QuoteRepository.IncrementDownloads(quote.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
