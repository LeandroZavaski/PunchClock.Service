using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;

namespace PunchClock.Service.Persistence.Entities
{
    public class AuthResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cpf")]
        public string Document { get; set; }

        public bool FisrtAccess { get; set; }

        public string Token { get; set; }

        public static implicit operator AuthResponse(Auth prop)
        {
            return prop is null ? null : new AuthResponse()
            {
                Id = prop.Id,
                Document = prop.Document,
                FisrtAccess = prop.FirstAccess,
                Token = prop.Token
            };
        }
    }
}
