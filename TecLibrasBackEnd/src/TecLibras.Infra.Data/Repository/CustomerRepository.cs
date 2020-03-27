using System.Linq;
using TecLibras.Domain.Interfaces;
using TecLibras.Domain.Models;
using TecLibras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TecLibras.Infra.Data.Repository
{
    public class PointsRepository : Repository<Points>, IPointsRepository
    {
        public PointsRepository(TecLibrasContext context)
            : base(context)
        {

        }
    }
}
