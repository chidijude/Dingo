using Dingo.Api.Domain;
using MongoDB.Bson;

namespace Dingo.Api.Persistence;

public class InMemoryArticleRepository : IArticleRepository
{
    private List<Article> _articles = [];
    public void Create(Article article)
    {
        _articles.Add(article);
    }

    public Article? Get(Guid articleId)
    {
        return _articles.Find(a => a.Id == articleId);
    }
    public bool Exists(Guid articleId)
    {
        return _articles.Any(article => article.Id == articleId);
    }
}