using MongoDB.Bson.Serialization.Attributes;

namespace CheckListBuild_BE.Entities
{
    public class CheckList
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new();

        public String UserId { get; set; }  
    }
}
