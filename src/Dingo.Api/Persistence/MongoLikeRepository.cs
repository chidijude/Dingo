using Dingo.Api.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dingo.Api.Persistence;

public class MongoLikeRepository(IMongoDatabase database) : ILikeRepository
{
    private const string CollectionName = "likes";
    private readonly IMongoCollection<Like> _collection = database.GetCollection<Like>(CollectionName);

    public void Create(Like like)
    {
        _collection.InsertOne(like);
    }

    public int GetLikeCount(Guid articleId)
    {
        var likecount = _collection.CountDocuments(f => f.ArticleId == articleId);
        return (int)likecount;
    }
}