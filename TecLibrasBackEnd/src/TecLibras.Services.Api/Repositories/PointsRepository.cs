using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Repositories
{
     public class PointsRepository : Repository<Points>, IPointsRepository
    {
        public PointsRepository(TecLibrasContext context)
            : base(context)
        {

        }
    }
}