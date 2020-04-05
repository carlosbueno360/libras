using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Repositories
{
    public class RankRepository : Repository<Rank>, IRankRepository
    {
        public RankRepository(TecLibrasContext context)
            : base(context)
        {

        }


        public Rank GetByUserId(Guid userId)
        {
            return DbSet.AsNoTracking().SingleOrDefault(c => c.UserId == userId);
        }
    }
}
