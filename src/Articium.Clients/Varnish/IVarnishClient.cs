namespace Articium.Clients;

public interface IVarnishClient
{
    Task PurgeAsync(string queryString);
}

