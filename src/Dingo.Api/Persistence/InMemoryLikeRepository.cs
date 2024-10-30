using Dingo.Api.Domain;
using MongoDB.Bson;

namespace Dingo.Api.Persistence;

public class InMemoryLikeRepository : ILikeRepository
{
    private List<Like> _likes = [];
    public void Create(Like like)
    {
        _likes.Add(like);
    }

    public int GetLikeCount(Guid articleId)
    {
        return _likes.Count(like => like.ArticleId == articleId);
    }
}