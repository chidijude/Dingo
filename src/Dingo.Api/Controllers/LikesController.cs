using Dingo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Api.Controllers;

[ApiController]
[Route("[controller]/{articleId}/like")]
public class LikesController(ArticleService articleService, LikeService likeService) : ControllerBase
{
    private readonly ArticleService _articleService = articleService;
    private readonly LikeService _likeService = likeService;
    [HttpGet]
    public ActionResult<int> Get(Guid articleId)
    {
        var articleExists = _articleService.ArticleExists(articleId);
        if (!articleExists)
        {
            return NotFound("Article not found");
        }
        var likeCount = _likeService.GetLikeCount(articleId);
        return Ok(likeCount);
    }

    [HttpPost]
    public IActionResult Like(Guid articleId)
    {
        var articleExists = _articleService.ArticleExists(articleId);
        if (!articleExists)
        {
            return NotFound("Article not found");
        }
        _likeService.AddLike(articleId, 1);
        return Created();
    }
}