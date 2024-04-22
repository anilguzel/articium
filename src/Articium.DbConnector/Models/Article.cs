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

    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ArticleContent { get; private set; }
    public DateTime PublishDate { get; private set; }
    public int StarCount { get; private set; }

    public void Update(string title, string articleContent, int starCount)
    {
        // check validations or sth
        this.Title = title;
        this.ArticleContent = articleContent;
        this.StarCount = starCount;
    }
}

