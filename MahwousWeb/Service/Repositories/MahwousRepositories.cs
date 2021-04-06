using MahwousWeb.Models.Models;
using MahwousWeb.Service.Services;
using System;
using System.Net.Http;

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
    }



    public class MahwousRepositories
    {
        private IHttpService httpService;
        private static readonly string url = @"https://www.mahwous.com/";

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


        public void Initialize()
        {
            var uri = new Uri(url);
            var httpClient = new HttpClient { BaseAddress = uri };
            httpService = new HttpService(httpClient);
        }

        #region Repositories


        private Repository<App> appsRepository;
        public Repository<App> AppsRepository
        {
            get
            {
                if (appsRepository is null)
                {
                    appsRepository = new Repository<App>(httpService, Constants.AppsUrl);
                }
                return appsRepository;
            }
        }


        private Repository<Category> categoriesRepository;
        public Repository<Category> CategoriesRepository
        {
            get
            {
                if (categoriesRepository is null)
                {
                    categoriesRepository = new Repository<Category>(httpService, Constants.CategoriesUrl);
                }
                return categoriesRepository;
            }
        }


        private NotificationRepository notificationsRepository;
        public NotificationRepository NotificationsRepository
        {
            get
            {
                if (notificationsRepository is null)
                {
                    notificationsRepository = new NotificationRepository(httpService, Constants.NotificationsUrl);
                }
                return notificationsRepository;
            }
        }


        private Repository<Post> postsRepository;
        public Repository<Post> PostsRepository
        {
            get
            {
                if (postsRepository is null)
                {
                    postsRepository = new Repository<Post>(httpService, Constants.PostsUrl);
                }
                return postsRepository;
            }
        }


        private StatusRepository<Status> statusesRepository;
        public StatusRepository<Status> StatusesRepository
        {
            get
            {
                if (statusesRepository is null)
                {
                    statusesRepository = new StatusRepository<Status>(httpService, Constants.StatusesUrl);
                }
                return statusesRepository;
            }
        }


        private StatusRepository<VideoStatus> videosRepository;
        public StatusRepository<VideoStatus> VideosRepository
        {
            get
            {
                if (videosRepository is null)
                {
                    videosRepository = new StatusRepository<VideoStatus>(httpService, Constants.VideosUrl);
                }
                return videosRepository;
            }
        }


        private StatusRepository<ImageStatus> imagesRepository;
        public StatusRepository<ImageStatus> ImagesRepository
        {
            get
            {
                if (imagesRepository is null)
                {
                    imagesRepository = new StatusRepository<ImageStatus>(httpService, Constants.ImagesUrl);
                }
                return imagesRepository;
            }
        }


        private StatusRepository<QuoteStatus> quotesRepository;
        public StatusRepository<QuoteStatus> QuotesRepository
        {
            get
            {
                if (quotesRepository is null)
                {
                    quotesRepository = new StatusRepository<QuoteStatus>(httpService, Constants.QuotesUrl);
                }
                return quotesRepository;
            }
        }

        #endregion

    }
}
