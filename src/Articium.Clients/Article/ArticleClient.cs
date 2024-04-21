using System.Net;
using Articium.Clients.Article.Models;
using Articium.Utils;

namespace Articium.Clients;

public class ArticleClient : IArticleClient
{
    public HttpClient Client { get; private set; }

    public ArticleClient(HttpClient client)
    {
        Client = client;
    }
    public async Task<GetArticleResponse> GetArticle(Guid articleId)
    {
        var message = await Client.GetAsync($"?id={articleId}");
        return await message.DeserializeContentAsync<GetArticleResponse>();
    }
}

