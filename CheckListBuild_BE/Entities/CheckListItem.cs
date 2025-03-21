using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckListBuild_BE.Entities
{
    public class CheckListItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public bool IsChecked { get; set; }
        public string Content { get; set; }

        [BsonElement("checklistId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ChecklistId { get; set; }

        [BsonElement("parentItemId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ParentItemId { get; set; } 

        [BsonElement("children")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Children { get; set; } = new(); 
    }

}
