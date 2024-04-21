namespace Articium.Clients;

public class VarnishClient : IVarnishClient
{
    public HttpClient Client { get; private set; }

    public VarnishClient(HttpClient client)
    {
        Client = client;
    }

    public async Task PurgeAsync(string queryString)
    {
        await Client.DeleteAsync(queryString);
    }
}