using AutoMapper;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    // Todo: initialize quote count
    public class QuoteViewModel : BaseViewModel
    {
        readonly QuoteStatus quote;

        public QuoteStatus Quote => quote;


        public QuoteViewModel(Mahwous.Core.Entities.QuoteStatus quote)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mahwous.Core.Entities.QuoteStatus, QuoteStatus>();
            });

            IMapper mapper = config.CreateMapper();

            this.quote = mapper.Map<QuoteStatus>(quote);

            ToggleLikeCommand = new Command(async () => await ExecuteToggleLikeCommand());
            CopyQuoteCommand = new Command(async () => await ExecuteCopyQuoteCommand());
            ShareQuoteCommand = new Command(async () => await ExecuteShareQuoteCommand());
            ShareQuoteWhatsCommand = new Command(async () => await ExecuteShareQuoteWhatsCommand());
            ShareQuoteFaceCommand = new Command(async () => await ExecuteShareQuoteFaceCommand());

            //Repositories.QuoteStatusRepository.IncrementViews(Quote.Id).ConfigureAwait(false);

            MahwousSqliteDB<QuoteStatus> database = new MahwousSqliteDB<QuoteStatus>();
            Liked = database.Exists(Quote);
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
        private async Task ExecuteToggleLikeCommand()
        {

            if (Liked)
            {
                try
                {
                    LikesCount--;
                    Liked = false;
                    //await Repositories.QuoteStatusRepository.DecrementLikes(quote.Id);

                    using (MahwousSqliteDB<QuoteStatus> database = new MahwousSqliteDB<QuoteStatus>())
                    {
                        database.Remove(Quote);
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
                    //await Repositories.QuoteStatusRepository.IncrementLikes(quote.Id);

                    using (MahwousSqliteDB<QuoteStatus> database = new MahwousSqliteDB<QuoteStatus>())
                    {
                        database.Add(Quote);
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


        public ICommand CopyQuoteCommand { get; }
        public ICommand ShareQuoteCommand { get; }
        public ICommand ShareQuoteWhatsCommand { get; }
        public ICommand ShareQuoteFaceCommand { get; }



        private async Task ExecuteCopyQuoteCommand()
        {
            Quote.DownloadsCount++;

            await Clipboard.SetTextAsync(quote.Content);
            DependencyService.Get<IMessage>().ShortAlert("تم نسخ الحالة إلى الحافظة");
            await IncrementDownloads();
        }
        private async Task ExecuteShareQuoteCommand()
        {
            Quote.DownloadsCount++;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = quote.Content,
                Title = "مشاركة حالة مهووس"
            });
            await IncrementDownloads();
        }
        private async Task ExecuteShareQuoteWhatsCommand()
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
        private async Task ExecuteShareQuoteFaceCommand()
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
                //await Repositories.QuoteStatusRepository.IncrementDownloads(quote.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
