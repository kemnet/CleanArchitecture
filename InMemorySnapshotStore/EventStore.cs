using System;
using System.Collections.Generic;
using System.Linq;
using Persistance;

namespace InMemorySnapshotStore
{
    public class EventStore : IEventStore
    {
        private List<IEvent> events = new List<IEvent>();
        
        public void Save(IEvent e)
        {
            if (e.Version != events.Count) {
                throw new Exception($"concurrency error: message with Version: {e.Version} ia already exists");
            }
            
            events.Add(e);
        }

        public IEnumerable<IEvent> Events()
        {
            return events.AsEnumerable();
        }

        public IEnumerable<IEvent> Events(long version)
        {
            return events.Where(e => e.Version > version);
        }

        public IEnumerable<IEvent> Events(long version, Guid aggregateId)
        {
            return events
                .Where(e => e.Version > version)
                .Where(e => e.AggregateId == aggregateId);
        }
    }
}