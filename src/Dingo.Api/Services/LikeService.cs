using Dingo.Api.Domain;
using Dingo.Api.Persistence;
using MongoDB.Bson;

namespace Dingo.Api.Services;

public class LikeService(ILikeRepository likeRepository)
{
    private readonly ILikeRepository _likeRepository = likeRepository;
    public void AddLike(Guid articleId, int userId = 0)
    {
        var like = new Like()
        {
            ArticleId = articleId,
            CreatedAt = DateTime.UtcNow,
            UserId = userId // 0 for anonymouse user
        };
        _likeRepository.Create(like);
    }
    
    public int GetLikeCount(Guid articleId)
    {
        return _likeRepository.GetLikeCount(articleId);
    }
}