using System;
using TecLibras.Domain.Core.Commands;

namespace TecLibras.Domain.Commands
{
    public abstract class PointsCommand : Command
    {
        public Guid Id { get; protected set; }

        public int Points { get; protected set; }
    }
}