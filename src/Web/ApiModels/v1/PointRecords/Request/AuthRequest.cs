using DelMazo.PointRecord.Service.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class AuthRequest
    {
        [BindRequired]
        [JsonProperty("cpf")]
        public string Document { get; set; }
        [BindRequired]
        [JsonProperty("senha")]
        public string Password { get; set; }

        public static implicit operator Auth(AuthRequest prop)
        {
            return prop is null ? null : new Auth()
            {
                Document = prop.Document,
                Password = prop.Password
            };
        }
    }
}
