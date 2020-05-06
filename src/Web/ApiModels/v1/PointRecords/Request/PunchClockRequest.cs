using DelMazo.PointRecord.Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class PunchClockRequest : BaseUserRequest
    {
        public static implicit operator PunchClock(PunchClockRequest prop)
        {
            return prop is null ? null : new PunchClock()
            {
                Id = prop.Id,
                Document = prop.Document
            };
        }
    }
}
