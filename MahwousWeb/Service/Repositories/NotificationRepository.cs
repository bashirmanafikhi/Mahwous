using MahwousWeb.Models.Models;
using MahwousWeb.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class NotificationRepository : Repository<Notification>
    {
        public NotificationRepository(IHttpService httpService, string url) : base(httpService, url) { }



        public async Task<Notification> GetLastNotification(string packageName)
        {
            var response = await httpService.Get<Notification>($"{url}/getLastNotification?packageName={packageName}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }



        public async Task IncrementOpened(int id)
        {
            var response = await httpService.Put($"{url}/IncrementOpened/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }



        public async Task IncrementRecived(int id)
        {
            var response = await httpService.Put($"{url}/IncrementRecived/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


    }
}
