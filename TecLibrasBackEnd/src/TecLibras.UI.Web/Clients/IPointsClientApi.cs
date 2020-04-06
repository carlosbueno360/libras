using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecLibras.UI.Web.ViewComponents;

namespace TecLibras.UI.Web.Clients
{
    public interface IPointsClientApi
    {
        Task<List<PointsViewModel>> GetPointsByUserId(Guid userId);
        Task<List<RankViewModel>> GetPointsRank();
    }
}