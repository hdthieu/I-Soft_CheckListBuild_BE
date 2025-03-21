using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static CheckListBuild_BE.Enum.Enum;

namespace CheckListBuild_BE.Entities
{
    public class PermissionDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string PermissionId { get; set; }

        public bool ViewFlag { get; set; }
        public bool CreateFlag { get; set; }
        public bool EditFlag { get; set; }
        public bool DeleteFlag { get; set; }
        public bool RequestFlag { get; set; }
        public bool ApproveFlag { get; set; }

        [BsonRepresentation(BsonType.String)]
        public EnumEnableFlag EnabledFlag { get; set; }
    }

}
