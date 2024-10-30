using Dingo.Api.Domain;
using Dingo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticlesController(ArticleService articleService)
    : ControllerBase
{
    private readonly ArticleService _articleServcie = articleService;

    [HttpGet("{articleId:guid}")]
    public ActionResult<ArticleResposne> Get(Guid articleId)
    {
        var article = _articleServcie.Get(articleId);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(ArticleResposne.FromDomain(article));
    }

    [HttpPost]
    public IActionResult Create(ArticleRequest request)
    {
        Article article = new()
        {
            Title = request.Title,
            Content = request.Content,
            DateCreated = DateTime.UtcNow
        };

        _articleServcie.Create(article);
        return CreatedAtAction(
            nameof(Get),
            new { articleId = article.Id.ToString() },
            ArticleResposne.FromDomain(article));
    }
}

public record ArticleRequest(string Title, string Content);

public record ArticleResposne(string Title, string Content, string DateCreated)
{
    public static ArticleResposne FromDomain(Article article)
    {
        return new ArticleResposne(article.Title, article.Content, article.DateCreated.ToString("s"));
    }
};