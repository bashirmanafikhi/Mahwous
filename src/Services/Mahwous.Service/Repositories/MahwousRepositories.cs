using Mahwous.Service.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mahwous.Service.Repositories
{
    internal static class Constants
    {
        public const string MobileAppsUrl = "api/mobileApps";
        public const string MessagesUrl = "api/messages";
        public const string CategoriesUrl = "api/categories";
        public const string NotificationsUrl = "api/mobileNotifications";
        public const string PostsUrl = "api/posts";
        public const string ChatRoomsUrl = "api/chatRooms";
        public const string ExternalLinksUrl = "api/externalLinks";
        public const string StatusesUrl = "api/statuses";
        public const string VideosUrl = "api/videoStatuses";
        public const string ImagesUrl = "api/imageStatuses";
        public const string QuotesUrl = "api/quoteStatuses";
        public const string AccountsUrl = "api/accounts";
        public const string ReportsUrl = "api/reports";
        public const string URL = @"https://www.mahwous.com/";
    }

    public class MahwousRepositories
    {
        private IHttpService httpService;

        public MahwousRepositories()
            : this(Constants.URL)
        {
        }

        public MahwousRepositories(string url)
            : this(new HttpClient { BaseAddress = new Uri(url) })
        {
        }

        public MahwousRepositories(HttpClient httpClient)
            : this(new HttpService(httpClient))
        {
        }

        private MahwousRepositories(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public string Token
        {
            set => this.httpService.HttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", value);
            get => this.httpService.HttpClient.DefaultRequestHeaders.Authorization.Parameter;
        }


        public void Initialize()
        {
            var uri = new Uri(Constants.URL);
            var httpClient = new HttpClient { BaseAddress = uri };
            httpService = new HttpService(httpClient);
        }

        #region Repositories

        private ReportRepository reportsRepository;
        public ReportRepository ReportsRepository
        {
            get
            {
                if (reportsRepository == null)
                    reportsRepository = new ReportRepository(httpService, Constants.ReportsUrl);
                return reportsRepository;
            }
        }

        private MessageRepository messagesRepository;
        public MessageRepository MessagesRepository
        {
            get
            {
                if (messagesRepository == null)
                    messagesRepository = new MessageRepository(httpService, Constants.MessagesUrl);
                return messagesRepository;
            }
        }

        private MobileAppRepository mobileAppsRepository;
        public MobileAppRepository MobileAppsRepository
        {
            get
            {
                if (mobileAppsRepository == null)
                    mobileAppsRepository = new MobileAppRepository(httpService, Constants.MobileAppsUrl);
                return mobileAppsRepository;
            }
        }

        private CategoryRepository categoriesRepository;
        public CategoryRepository CategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoryRepository(httpService, Constants.CategoriesUrl);
                return categoriesRepository;
            }
        }

        private MobileNotificationRepository mobileNotificationsRepository;
        public MobileNotificationRepository MobileNotificationsRepository
        {
            get
            {
                if (mobileNotificationsRepository == null)
                    mobileNotificationsRepository = new MobileNotificationRepository(httpService, Constants.NotificationsUrl);
                return mobileNotificationsRepository;
            }
        }

        private PostRepository postRepository;
        public PostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(httpService, Constants.PostsUrl);
                return postRepository;
            }
        }

        private ChatRoomRepository chatRoomRepository;
        public ChatRoomRepository ChatRoomRepository
        {
            get
            {
                if (chatRoomRepository == null)
                    chatRoomRepository = new ChatRoomRepository(httpService, Constants.ChatRoomsUrl);
                return chatRoomRepository;
            }
        }

        private ExternalLinkRepository externalLinkRepository;
        public ExternalLinkRepository ExternalLinkRepository
        {
            get
            {
                if (externalLinkRepository == null)
                    externalLinkRepository = new ExternalLinkRepository(httpService, Constants.ExternalLinksUrl);
                return externalLinkRepository;
            }
        }

        private AccountsRepository accountsRepository;
        public AccountsRepository AccountsRepository
        {
            get
            {
                if (accountsRepository == null)
                    accountsRepository = new AccountsRepository(httpService);
                return accountsRepository;
            }
        }

        private VideoStatusRepository videoStatusRepository;
        public VideoStatusRepository VideoStatusRepository
        {
            get
            {
                if (videoStatusRepository == null)
                    videoStatusRepository = new VideoStatusRepository(httpService, Constants.VideosUrl);
                return videoStatusRepository;
            }
        }


        private ImageStatusRepository imageStatusRepository;
        public ImageStatusRepository ImageStatusRepository
        {
            get
            {
                if (imageStatusRepository == null)
                    imageStatusRepository = new ImageStatusRepository(httpService, Constants.ImagesUrl);
                return imageStatusRepository;
            }
        }


        private QuoteStatusRepository quoteStatusRepository;
        public QuoteStatusRepository QuoteStatusRepository
        {
            get
            {
                if (quoteStatusRepository == null)
                    quoteStatusRepository = new QuoteStatusRepository(httpService, Constants.QuotesUrl);
                return quoteStatusRepository;
            }
        }

        #endregion

    }
}
