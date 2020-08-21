using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MahwousWeb.Shared.Filters;
using System.Linq;

namespace MahwousWeb.Shared.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        protected string url = "api/notifications";

        private readonly IHttpService httpService;


        public NotificationRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task Add(Notification notification)
        {
            var response = await httpService.Post(url, notification);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<Notification> Get(int id)
        {
            var response = await httpService.Get<Notification>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<Notification> GetNewest()
        {
            var response = await httpService.Get<Notification>($"{url}/GetLastNotification");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<Notification>>> GetNotifications(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Notification>>(url, paginationDTO);
        }

        public async Task Update(Notification notification)
        {
            var response = await httpService.Put(url, notification);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task IncreaseOpenedCount(Notification notification)
        {
            var response = await httpService.Post($"{url}/IncreaseOpenedCount", notification);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task IncreaseRecivedCount(Notification notification)
        {
            var response = await httpService.Post($"{url}/IncreaseRecivedCount", notification);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
