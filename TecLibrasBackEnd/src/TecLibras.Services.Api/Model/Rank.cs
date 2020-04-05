
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.Services.Api.Model
{
    public class Rank : Entity
    {
        public Rank(Guid userId, int points)
        {
            Id = Guid.NewGuid();
            Points = points;
            UserId = userId;
        }

        protected Rank() { }

        public Guid UserId { get; private set; }

        public int Points { get; private set; }

    }
}
