using DelMazo.PointRecord.Service.Domain.Entities;
using Newtonsoft.Json;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class AuthResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cpf")]
        public string Document { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string Token { get; set; }

        public static implicit operator AuthResponse(Auth prop)
        {
            return prop is null ? null : new AuthResponse()
            {
                Id = prop.Id,
                Document = prop.Document,
                Token = prop.Token
            };
        }
    }
}
