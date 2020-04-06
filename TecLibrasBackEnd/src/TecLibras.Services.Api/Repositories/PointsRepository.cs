using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Repositories
{
     public class PointEventRepository : Repository<PointEvent>, IPointEventRepository
    {
        public PointEventRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<PointEvent> GetByUserId(Guid userId)
        {
            return DbSet.AsNoTracking().Where(c => c.UserId == userId);
        }
    }
}