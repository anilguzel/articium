using Articium.Clients;
using MediatR;

namespace Articium.EventServices;

public class CacheInvalidationEventHandler : INotificationHandler<CacheInvalidationEvent>
{
    private readonly IVarnishClient _varnishClient;
    public CacheInvalidationEventHandler(IVarnishClient varnishClient)
    {
        _varnishClient = varnishClient;
    }

    public async Task Handle(CacheInvalidationEvent notification, CancellationToken cancellationToken)
    {
        await _varnishClient.PurgeAsync(notification.Id);
    }
}
