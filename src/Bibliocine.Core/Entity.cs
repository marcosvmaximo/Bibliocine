using Bibliocine.Core.Messages.Common;

namespace Bibliocine.Core;
public abstract class Entity
{
    private List<Event> _events;
    public Entity()
    {
        Id = Guid.NewGuid();
        TimeStamp = DateTime.Now;
        
        _events = new();
    }
    
    public Guid Id { get; init; }
    public DateTime TimeStamp { get; init; }
    public IReadOnlyCollection<Event> Events => _events;
    
    public abstract void Validar();
    
    public void AddEvent(Event @event) => _events.Add(@event);
    public void AddEvent(IEnumerable<Event> @event) => _events.AddRange(@event);
    public void CleanEvents() => _events = new();
    
    
    public override bool Equals(object? obj)
    {
        var compareToo = obj as Entity;

        if (ReferenceEquals(compareToo, null))
            return false;

        if (ReferenceEquals(compareToo, this))
            return true;

        return Id.Equals(this.Id);
    }
    
    public static bool operator ==(Entity? a, Entity? b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;
        
        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }
    
    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}