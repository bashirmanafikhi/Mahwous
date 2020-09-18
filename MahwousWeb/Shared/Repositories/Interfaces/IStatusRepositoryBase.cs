using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IStatusRepositoryBase
    {
        Task IncrementViews(int id);
        Task IncrementDownloads(int id);
        Task IncrementLikes(int id);
        Task DecrementLikes(int id);
        Task<GeneralInformations> GetGeneralInformations();
    }
}
