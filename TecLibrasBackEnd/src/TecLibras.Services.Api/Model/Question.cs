using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.Services.Api.Model
{
    public class Question : Entity
    {
        public Question(int level, int points, string title, string awser)
        {
            Id = Guid.NewGuid();
            Awnser = awser;
            Points = points;
            Title = title;
            Level = level;
        }

        public int Level { get; private set; }

        public int Points { get; private set; }

        public string Title { get; private set; }

        public string Awnser { get; private set; }
    }
}
