using System;
using System.Collections.Generic;
using TecLibras.Domain.Core.Events;

namespace TecLibras.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}