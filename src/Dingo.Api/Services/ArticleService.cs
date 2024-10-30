using Dingo.Api.Domain;
using Dingo.Api.Persistence;
using MongoDB.Bson;

namespace Dingo.Api.Services;

public class ArticleService(IArticleRepository articleRepository)
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    public bool ArticleExists(Guid articleId)
    {
        return _articleRepository.Exists(articleId);
    }
    public Article? Get(Guid articleId)
    {
        return _articleRepository.Get(articleId);
    }
    
    public void Create(Article article)
    {
        _articleRepository.Create(article);
    }
}