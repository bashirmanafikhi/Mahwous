using MahwousWeb.Models.Models;
using MahwousWeb.Service.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MahwousWeb.Service.Repositories
{
    internal static class Constants
    {
        public static string AppsUrl = "api/apps";
        public static string CategoriesUrl = "api/categories";
        public static string NotificationsUrl = "api/notifications";
        public static string PostsUrl = "api/posts";
        public static string StatusesUrl = "api/statuses";
        public static string VideosUrl = "api/videos";
        public static string ImagesUrl = "api/images";
        public static string QuotesUrl = "api/quotes";
        public static string AccountsUrl = "api/accounts";
    }

    public class MahwousRepositories
    {
        private IHttpService httpService;
        private static readonly string url = @"https://www.mahwous.com/";
        private static readonly string local = @"http://192.168.0.113:60485/";

        public MahwousRepositories()
            : this(url)
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
            set
            {
                this.httpService.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", value);
            }
        }


        public void Initialize()
        {
            var uri = new Uri(url);
            var httpClient = new HttpClient { BaseAddress = uri };
            httpService = new HttpService(httpClient);
        }

        #region Repositories


        private AppRepository appsRepository;
        public AppRepository AppsRepository
        {
            get
            {
                if (appsRepository == null)
                {
                    appsRepository = new AppRepository(httpService, Constants.AppsUrl);
                }
                return appsRepository;
            }
        }


        private CategoryRepository categoriesRepository;
        public CategoryRepository CategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new CategoryRepository(httpService, Constants.CategoriesUrl);
                }
                return categoriesRepository;
            }
        }

        private NotificationRepository notificationsRepository;
        public NotificationRepository NotificationsRepository
        {
            get
            {
                if (notificationsRepository == null)
                {
                    notificationsRepository = new NotificationRepository(httpService, Constants.NotificationsUrl);
                }
                return notificationsRepository;
            }
        }


        private PostRepository postsRepository;
        public PostRepository PostsRepository
        {
            get
            {
                if (postsRepository == null)
                {
                    postsRepository = new PostRepository(httpService, Constants.PostsUrl);
                }
                return postsRepository;
            }
        }

        private AccountsRepository accountsRepository;
        public AccountsRepository AccountsRepository
        {
            get
            {
                if (accountsRepository == null)
                {
                    accountsRepository = new AccountsRepository(httpService);
                }
                return accountsRepository;
            }
        }


        private StatusRepository<Status> statusesRepository;
        public StatusRepository<Status> StatusesRepository
        {
            get
            {
                if (statusesRepository == null)
                {
                    statusesRepository = new StatusRepository<Status>(httpService, Constants.StatusesUrl);
                }
                return statusesRepository;
            }
        }


        private VideoRepository videosRepository;
        public VideoRepository VideosRepository
        {
            get
            {
                if (videosRepository == null)
                {
                    videosRepository = new VideoRepository(httpService, Constants.VideosUrl);
                }
                return videosRepository;
            }
        }


        private ImageRepository imagesRepository;
        public ImageRepository ImagesRepository
        {
            get
            {
                if (imagesRepository == null)
                {
                    imagesRepository = new ImageRepository(httpService, Constants.ImagesUrl);
                }
                return imagesRepository;
            }
        }


        private QuoteRepository quotesRepository;
        public QuoteRepository QuotesRepository
        {
            get
            {
                if (quotesRepository == null)
                {
                    quotesRepository = new QuoteRepository(httpService, Constants.QuotesUrl);
                }
                return quotesRepository;
            }
        }

        #endregion

    }
}
