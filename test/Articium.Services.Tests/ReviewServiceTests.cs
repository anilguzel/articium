using Articium.Clients;
using Articium.DbConnector;
using Articium.DbConnector.Models;
using Moq;

public class ReviewServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectReview()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var review = new Review(articleId, "Test Review", "Test Content" );

        var articleClientMock = new Mock<IArticleClient>();
        var dbContextMock = new Mock<ArticiumDbContext>();
        dbContextMock.Setup(m => m.Reviews.FindAsync(review.Id)).ReturnsAsync(review);

        var service = new ReviewService(dbContextMock.Object, articleClientMock.Object);

        // Act
        var result = await service.GetByIdAsync(review.Id);

        // Assert
        Assert.Equal(review.Id, result.Id);
        Assert.Equal("Test Review", result.ReviewContent);
    }
}
