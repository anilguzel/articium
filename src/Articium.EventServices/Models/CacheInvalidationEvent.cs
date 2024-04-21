namespace Articium.EventServices;

public class CacheInvalidationEvent : MediatR.INotification
{
    public CacheInvalidationEvent(string id)
    {
        Id = id;
    }

    public string Id { get; }
}