using DelMazo.PointRecord.Service.Domain.Entities;
using Newtonsoft.Json;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class PunchClockRequest
    {
        [JsonProperty("cpf")]
        public string Document { get; set; }

        public static implicit operator PunchClock(PunchClockRequest prop)
        {
            return prop is null ? null : new PunchClock()
            {
                Document = prop.Document
            };
        }
    }
}
