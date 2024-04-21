using Articium.DbConnector.Models;
using Articium.Services.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticlesController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> Get(Guid id)
    {
        var article = await _articleService.GetByIdAsync(id);
        if (article == null)
        {
            return NotFound();
        }

        return Ok(article);
    }
    

    //[HttpGet]
    //public async Task<ActionResult<Article>> Get([FromQuery] Dictionary<string, string> filters)
    //{
    //    var article = await _articleService.GetByFilterAsync(filters);
    //    if (article == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(article);
    //}
    
    [HttpPost]
    public async Task<ActionResult<Article>> Create(ArticleRequestModel article)
    {
        return await _articleService.CreateAsync(article);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ArticleRequestModel article)
    {
        var result = await _articleService.UpdateAsync(id, article);
        if (result == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _articleService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
