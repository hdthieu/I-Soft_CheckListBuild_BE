using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CheckListBuild_BE.Entities
{
    public class JobTitle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; }
    }
}
