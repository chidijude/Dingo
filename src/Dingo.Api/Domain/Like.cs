using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dingo.Api.Domain;

public class Like
{
    [BsonId]
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}