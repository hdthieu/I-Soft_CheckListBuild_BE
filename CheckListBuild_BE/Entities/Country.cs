using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CheckListBuild_BE.Entities
{
    public class Country
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string InternationalDialingCode { get; set; }
    }
}
