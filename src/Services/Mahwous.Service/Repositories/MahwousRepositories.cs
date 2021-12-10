using Mahwous.Service.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mahwous.Service.Repositories
{
    internal static class Constants
    {
        public static string MobileAppsUrl = "api/mobileApps";
        public static string MessagesUrl = "api/messages";
        public static string CategoriesUrl = "api/categories";
        public static string NotificationsUrl = "api/mobileNotifications";
        public static string PostsUrl = "api/posts";
        public static string ChatRoomsUrl = "api/chatRooms";
        public static string ExternalLinksUrl = "api/externalLinks";
        public static string StatusesUrl = "api/statuses";
        public static string VideosUrl = "api/videoStatuses";
        public static string ImagesUrl = "api/imageStatuses";
        public static string QuotesUrl = "api/quoteStatuses";
        public static string AccountsUrl = "api/accounts";
        public static readonly string URL = @"https://www.mahwous.com/";
        //public static readonly string IP = @"http://192.168.0.113:60485/";
        //public static readonly string Localhost = @"http://localhost:60485/";
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
