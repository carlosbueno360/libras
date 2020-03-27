using System;
using System.Collections.Generic;
using TecLibras.Application.ViewModels;

namespace TecLibras.Application.Interfaces
{
    public interface IPointsAppService : IDisposable
    {
        void Register(PointsViewModel pointsViewModel);
        IEnumerable<PointsViewModel> GetAll();
        PointsViewModel GetById(Guid id);
    }
}
