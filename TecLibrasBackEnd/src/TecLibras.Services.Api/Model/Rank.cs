
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
            ApplicationUserId = userId.ToString();
        }

        public void Update(int points) 
        {
            Points = points;
        }

        protected Rank() { }

        public string ApplicationUserId { get; private set; }

        public int Points { get; private set; }


        public ApplicationUser ApplicationUser { get; private set; }

    }
}
