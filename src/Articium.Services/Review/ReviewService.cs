using Articium.Clients;
using Articium.DbConnector;
using Articium.DbConnector.Models;
using Articium.Services.Models;
using Microsoft.EntityFrameworkCore;

public class ReviewService : IReviewService
{
    private readonly ArticiumDbContext _dbContext;
    private readonly IArticleClient _articleClient;

    public ReviewService(ArticiumDbContext dbContext, IArticleClient articleClient)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "DbContext cannot be null.");
        _articleClient = articleClient;
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        return await _dbContext.Reviews.FindAsync(id);
    }

    public async Task<List<Review>> GetByFilterAsync(Dictionary<string, string> filters)
    {
        var queryBuilder = new QueryBuilder<Review>();
        var predicate = queryBuilder.BuildQuery(filters);

        return await _dbContext.Reviews.Where(predicate).ToListAsync();
    }

    public async Task<Review> CreateAsync(ReviewRequestModel request)
    {
        var article = await _articleClient.GetArticle(request.ArticleId);

        var review = new Review(request.ArticleId, request.Reviewer, request.ReviewContent);
        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();
        return review;
    }

    public async Task<Review> UpdateAsync(Guid reviewId, ReviewRequestModel request)
    {
        var review = await _dbContext.Reviews.FindAsync(reviewId);
        if (review == null)
            return null;

        review.ReviewContent = request.ReviewContent;
        review.Reviewer = request.Reviewer;

        _dbContext.Update(review);
        await _dbContext.SaveChangesAndInvalidateCacheAsync<Review>();

        return review;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var review = await GetByIdAsync(id);
        if (review == null)
            return false;

        _dbContext.Reviews.Remove(review); // considering soft-delete as better approach
        return await _dbContext.SaveChangesAndInvalidateCacheAsync<Review>();
    }
}
