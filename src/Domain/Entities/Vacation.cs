using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PunchClock.Service.Domain.Entities
{
    public partial class Vacation
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement]
        public string Registration { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public Document Document { get; set; }

        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? StartDate { get; set; }

        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? EndDate { get; set; }

        [BsonElement]
        public string DaysNumber { get; set; }

        [BsonElement]
        public bool Active { get; set; }
    }
}
