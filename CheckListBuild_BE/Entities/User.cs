using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static CheckListBuild_BE.Enum.Enum;

namespace CheckListBuild_BE.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }
        public string LastLoginIPAddress { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [BsonRepresentation(BsonType.String)]
        public EnumGender Gender { get; set; }

        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CountryId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public EnumEnableFlag EnabledFlag { get; set; }

        public bool LoginRememberFlag { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string JobTitleId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
    }
}
