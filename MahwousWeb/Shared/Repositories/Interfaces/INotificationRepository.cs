using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task Add(Notification notification);
        Task<Notification> Get(int id);
        Task<Notification> GetNewest();
        Task<PaginatedResponse<List<Notification>>> GetNotifications(PaginationDTO paginationDTO);
        Task Update(Notification notification);
        Task IncreaseOpenedCount(Notification notification);
        Task IncreaseRecivedCount(Notification notification);
        Task Delete(int Id);
    }
}
