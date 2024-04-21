namespace Articium.DbConnector.Models;

public class Review : TEntity
{
    public Review(Guid articleId, string reviewer, string reviewContent)
    {
        ArticleId = articleId;
        Reviewer = reviewer;
        ReviewContent = reviewContent;
    }

    public Guid ArticleId { get; set; }
    public string Reviewer { get; set; }
    public string ReviewContent { get; set; }

}