using System;
using Articium.DbConnector.Models;
using Articium.Services.Models;

public interface IReviewService
{
    Task<Review> GetByIdAsync(Guid id);
    Task<List<Review>> GetByFilterAsync(Dictionary<string, string> filters);
    Task<Review> CreateAsync(ReviewRequestModel request);
    Task<Review> UpdateAsync(Guid reviewId, ReviewRequestModel request);
    Task<bool> DeleteAsync(Guid id);
}
