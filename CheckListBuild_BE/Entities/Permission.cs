using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static CheckListBuild_BE.Enum.Enum;

namespace CheckListBuild_BE.Entities
{
    public class Permission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public EnumEnableFlag EnabledFlag { get; set; }
    }
}
