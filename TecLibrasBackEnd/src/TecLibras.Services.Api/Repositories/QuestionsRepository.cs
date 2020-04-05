using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecLibras.Services.Api.Context;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Repositories
{
    public class QuestionsRepository : Repository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(TecLibrasContext context)
            : base(context)
        {

        }
    }
}
