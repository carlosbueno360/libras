using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Repositories
{
    public interface IRankRepository : IRepository<Rank>
    {
        Rank GetByUserId(Guid userId);
    }
}
