using Articium.Clients.Article.Models;

namespace Articium.Clients;

public interface IArticleClient
{
    Task<GetArticleResponse> GetArticle(Guid articleId);
}

