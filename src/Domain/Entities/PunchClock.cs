using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PunchClock.Service.Domain.Entities
{
    public partial class PunchClock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement]
        public string Document { get; set; }
        [BsonElement]
        public DateTime? StartWork { get; set; }
        [BsonElement]
        public DateTime? FinishWork { get; set; }
    }
}
