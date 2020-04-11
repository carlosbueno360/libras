using AppTECLIBRAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTECLIBRAS.Clients
{
    public interface IPointsClientApi
    {
        Task<List<PointsViewModel>> GetPointsByUserId(Guid userId);
        Task<List<RankViewModel>> GetPointsRank();
    }
}