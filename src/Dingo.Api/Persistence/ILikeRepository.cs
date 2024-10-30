using Dingo.Api.Domain;
using MongoDB.Bson;

namespace Dingo.Api.Persistence
{
    public interface ILikeRepository
    {
        void Create(Like like);
        int GetLikeCount(Guid articleId);
    }
}