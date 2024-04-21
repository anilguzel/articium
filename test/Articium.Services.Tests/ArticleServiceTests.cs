using Articium.DbConnector;
using Articium.DbConnector.Models;
using Moq;

public class ArticleServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectArticle()
    {
        // Arrange
        var article = new Article("Test Article", "author", "content");

        var dbContextMock = new Mock<ArticiumDbContext>();
        dbContextMock.Setup(m => m.Articles.FindAsync(article.Id)).ReturnsAsync(article);

        var service = new ArticleService(dbContextMock.Object);

        // Act
        var result = await service.GetByIdAsync(article.Id);

        // Assert
        Assert.Equal(article.Id, result.Id);
        Assert.Equal("Test Article", result.Title);
    }
}
