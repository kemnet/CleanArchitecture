using System;
using System.Collections.Generic;

namespace Persistance
{
    public interface IEventStore
    {
        void Save(IEvent e);
        IEnumerable<IEvent> Events();
        IEnumerable<IEvent> Events(long version);
        IEnumerable<IEvent> Events(long version, Guid aggregateId);
    }
}