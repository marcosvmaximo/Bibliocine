using Bibliocine.Core.Messages.Common;

namespace Bibliocine.Core.Messages;

public class DomainEvent : Event
{
    public Guid AggregateId { get; init; }
    
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}