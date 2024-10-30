using Dingo.Api.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dingo.Api.Persistence;

public class MongoArticleRepository(IMongoDatabase database) : IArticleRepository
{
    private const string CollectionName = "articles";
    private readonly IMongoCollection<Article> _collection = database.GetCollection<Article>(CollectionName);
    public void Create(Article article)
    {
        _collection.InsertOne(article);
    }

    public bool Exists(Guid articleId)
    {
        var articleCount = _collection.CountDocuments(a => a.Id == articleId);
        return articleCount != 0;
    }

    public Article? Get(Guid articleId)
    {
        var article = _collection.Find(a => a.Id == articleId);
        return article.FirstOrDefault();
    }
}