using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Repositories
{
     public class PointEventRepository : Repository<PointEvent>, IPointEventRepository
    {
        public PointEventRepository(TecLibrasContext context)
            : base(context)
        {

        }
    }
}