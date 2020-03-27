using System;
using TecLibras.Domain.Core.Events;

namespace TecLibras.Domain.Events
{
    public class PointsRegisteredEvent : Event
    {
        public PointsRegisteredEvent(Guid id, int points)
        {
            Id = id;
            Points = points;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public int Points { get; private set; }
    }
}