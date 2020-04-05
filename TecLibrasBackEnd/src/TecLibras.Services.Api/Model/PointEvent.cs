using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.Services.Api.Model
{
    public class PointEvent : Entity
    {

        public PointEvent(Guid userId, int points )
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.UtcNow;
            Points = points;
            UserId = userId;
        }

        protected PointEvent() { }

        public int Points { get; private set; }

        public DateTime DateTime { get; private set; }

        public Guid UserId { get; private set; }
    }
}
