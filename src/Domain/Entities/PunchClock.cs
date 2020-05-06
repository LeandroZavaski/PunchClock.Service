using System;
using System.Text.Json.Serialization;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public class PunchClock : BaseUser
    {
        public DateTime? StartWork { get; set; } = null;
        public DateTime? FinishWork { get; set; } = null;
    }
}
