using Articium.DbConnector.Models;
using Articium.Services.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> Get(Guid id)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }


    //[HttpGet]
    //public async Task<ActionResult<Review>> Get([FromQuery] Dictionary<string, string> filters)
    //{
    //    var review = await _reviewService.GetByFilterAsync(filters);
    //    if (review == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(review);
    //}

    [HttpPost]
    public async Task<ActionResult<Review>> Create(ReviewRequestModel review)
    {
        return await _reviewService.CreateAsync(review);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ReviewRequestModel review)
    {
        var result = await _reviewService.UpdateAsync(id, review);
        if (result == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _reviewService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
