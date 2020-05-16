using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public class Auth
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement]
        public string Document { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        public bool FirstAccess { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
