using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Repositories
{
    public class RankRepository : Repository<Rank>, IRankRepository
    {
        public RankRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public List<Rank> GetAllWithApplicationUser()
        {
            return DbSet.AsNoTracking().Include(rep => rep.ApplicationUser).OrderByDescending(o=>o.Points).ToList();
        }

        public Rank GetByUserId(Guid userId)
        {
            return DbSet.AsNoTracking().Include(rep=>rep.ApplicationUser).SingleOrDefault(c => c.ApplicationUserId.Equals(userId.ToString()));
        }
    }
}
