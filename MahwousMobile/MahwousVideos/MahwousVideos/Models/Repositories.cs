using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousVideos.Models
{
    public class Repositories
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IVideoRepository VideoRepository { get; set; }
        public INotificationRepository NotificationRepository { get; set; }
        public IAppRepository AppRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
    }
}
