using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public class Role
    {
        [BsonId]
        public string Id { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public BsonBoolean Active { get; set; }
    }
}
