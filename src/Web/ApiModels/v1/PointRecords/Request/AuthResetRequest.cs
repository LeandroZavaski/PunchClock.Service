using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PunchClock.Service.Application.Helpers;
using PunchClock.Service.Domain.Entities;

namespace PunchClock.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class AuthResetRequest
    {
        [BindRequired]
        [JsonProperty("cpf")]
        public string Document { get; set; }

        [BindRequired]
        [JsonProperty("senha")]
        public string Password { get; set; }

        [BindRequired]
        [JsonProperty("senha")]
        public string ConfirmedPassword { get; set; }

        public static implicit operator Auth(AuthResetRequest prop)
        {
            return prop is null ? null : new Auth()
            {
                Document = prop.Document,
                Password = PointRecordHashPass.Encrypt(prop.Password),
                FirstAccess = false
            };
        }
    }
}
