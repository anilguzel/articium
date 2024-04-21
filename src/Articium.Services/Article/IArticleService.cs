using Articium.DbConnector.Models;
using Articium.Services.Models;

public interface IArticleService
{
    Task<Article> GetByIdAsync(Guid id);
    Task<List<Article>> GetByFilterAsync(Dictionary<string, string> filters);
    Task<Article> CreateAsync(ArticleRequestModel request);
    Task<Article> UpdateAsync(Guid articleId, ArticleRequestModel request);
    Task<bool> DeleteAsync(Guid id);
}
