using System;
using System.Collections.Generic;
using LawInOrderApp.Domain.Core.Events;

namespace LawInOrderApp.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);

    }
}
