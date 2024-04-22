using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articium.DbConnector;
using Articium.DbConnector.Models;
using Articium.Services.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class ArticleService : IArticleService
{
    private readonly ArticiumDbContext _dbContext;

    public ArticleService(ArticiumDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "DbContext cannot be null.");
    }

    public async Task<Article> GetByIdAsync(Guid id)
    {
        return await _dbContext.Articles.FindAsync(id);
    }

    public async Task<List<Article>> GetByFilterAsync(Dictionary<string, string> filters)
    {
        var queryBuilder = new QueryBuilder<Article>();
        var predicate = queryBuilder.BuildQuery(filters);

        return await _dbContext.Articles.Where(predicate).ToListAsync();
    }

    public async Task<Article> CreateAsync(ArticleRequestModel request)
    {
        var article = new Article(request.Title, request.Author, request.ArticleContent, request.StarCount);
        _dbContext.Articles.Add(article);
        await _dbContext.SaveChangesAsync();
        return article;
    }

    public async Task<Article> UpdateAsync(Guid articleId, ArticleRequestModel request)
    {
        var article = await _dbContext.Articles.FindAsync(articleId);
        if (article == null)
            return null;

        article.Update(request.Title, request.ArticleContent, request.StarCount);

        _dbContext.Update(article);
        await _dbContext.SaveChangesAndInvalidateCacheAsync<Article>();

        return article;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var article = await GetByIdAsync(id);
        if (article == null)
            return false;

        _dbContext.Articles.Remove(article);
        return await _dbContext.SaveChangesAndInvalidateCacheAsync<Article>();
    }
}
