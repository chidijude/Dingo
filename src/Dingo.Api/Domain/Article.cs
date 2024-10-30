using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dingo.Api.Domain;

public class Article
{
    [BsonId]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
}