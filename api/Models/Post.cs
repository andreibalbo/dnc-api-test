using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DncApiTest.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
} 