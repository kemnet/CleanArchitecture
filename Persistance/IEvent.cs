using System;

namespace Persistance
{
    public interface IEvent
    {
        long Version { get; }
        Guid AggregateId { get; }
    }
}