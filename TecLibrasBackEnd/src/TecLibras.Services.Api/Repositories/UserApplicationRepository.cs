using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Repositories
{
    public class UserApplicationRepository : Repository<ApplicationUser>, IUserApplicationRepository
    {
        public UserApplicationRepository(ApplicationDbContext context)
          : base(context)
        {

        }

        public ApplicationUser GetByUserName(string userName)
        {
            return DbSet.AsNoTracking().Where(o => o.UserName.Equals(userName)).SingleOrDefault();
        }
    }
}
