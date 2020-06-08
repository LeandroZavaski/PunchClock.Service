using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public partial class User
    {
        [BsonId]
        public string Id { get; set; }
       
        [BsonElement]
        public string Registration { get; set; }
       
        [BsonElement]
        public string Name { get; set; }
       
        [BsonElement]
        public DateTime BirthDate { get; set; }
        
        [BsonElement]
        public string Phone { get; set; }
       
        [BsonElement]
        public byte Gender { get; set; }
        
        [BsonElement]
        public string DocumentCpf { get; set; }
        
        [BsonElement]
        public string DocumentRg { get; set; }
        
        [BsonElement]
        public string DocumentPis { get; set; }
        
        [BsonElement]
        public Role Role { get; set; }
        
        [BsonElement]
        public string Email { get; set; }

        [BsonElement]
        public Address Address { get; set; }

        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime StartDate { get; set; }
        
        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? FinishDate { get; set; }

        [BsonElement]
        public string Shift { get; set; }

        [BsonElement]
        public BsonBoolean Active { get; set; }
        
        [BsonElement]
        public Auth Auth { get; set; }

        public IEnumerable<Collections> Collections { get; set; }
    }
}
