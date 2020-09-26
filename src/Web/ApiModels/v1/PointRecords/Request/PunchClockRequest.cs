using Newtonsoft.Json;

namespace PunchClock.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class PunchClockRequest
    {
        [JsonProperty("cpf")]
        public string Document { get; set; }

        public static implicit operator Domain.Entities.PunchClock(PunchClockRequest prop)
        {
            return prop is null ? null : new Domain.Entities.PunchClock()
            {
                Document = prop.Document
            };
        }
    }
}
