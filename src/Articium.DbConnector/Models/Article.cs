namespace Articium.DbConnector.Models;

public class Article : TEntity
{
    public Article(string title, string author, string articleContent, int starCount = 0)
    {
        Title = title;
        Author = author;
        ArticleContent = articleContent;
        PublishDate = DateTime.UtcNow;
        StarCount = starCount;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string ArticleContent { get; set; }
    public DateTime PublishDate { get; set; }
    public int StarCount { get; set; }
}

