using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DockerExample.Models
{
    //[BsonNoId]
    //[BsonIgnoreExtraElements]
    public class UserModel
    {
        [BsonId]
        [BsonElement("_id")]
        public required string Id { get; set; }
        [BsonElement("firstName"), BsonRepresentation(BsonType.String)]
        public string? FirstName { get; set; }
        [BsonElement("lastName"), BsonRepresentation(BsonType.String)]
        public string? LastName { get; set; }
        [BsonElement("age"), BsonRepresentation(BsonType.Int32)]
        public int Age{ get; set; }
    }
}
