using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public IQueryable<PointEvent> GetByUserId(Guid userId)
        {
            return DbSet.AsNoTracking().Where(c => c.UserId == userId);
        }
    }
}