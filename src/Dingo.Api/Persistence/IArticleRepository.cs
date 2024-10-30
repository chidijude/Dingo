using Dingo.Api.Domain;
using MongoDB.Bson;

namespace Dingo.Api.Persistence
{
    public interface IArticleRepository
    {
        void Create(Article article);
        bool Exists(Guid articleId);
        Article? Get(Guid articleId);
    }
}