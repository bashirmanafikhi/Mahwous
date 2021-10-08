using Mahwous.Core.Entities;
using MahwousWeb.Service.Services;
using System;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class NotificationRepository : Repository<MobileNotification>
    {
        public NotificationRepository(IHttpService httpService, string url) : base(httpService, url) { }

        public async Task<MobileNotification> GetLastNotification(string packageName)
        {
            try
            {
                var response = await httpService.Get<MobileNotification>($"{url}/getLastNotification?packageName={packageName}");
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
                return response.Response;
            }
            catch { return null; }
        }

        public async Task IncrementOpened(int id)
        {
            try
            {
                var response = await httpService.Put($"{url}/IncrementOpened/{id}");
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            }
            catch { }
        }

        public async Task IncrementRecived(int id)
        {
            try
            {
                var response = await httpService.Put($"{url}/IncrementRecived/{id}");
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            }
            catch { }
        }


    }
}
