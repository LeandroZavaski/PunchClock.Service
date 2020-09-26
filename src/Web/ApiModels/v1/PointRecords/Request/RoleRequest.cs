using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using System;

namespace PunchClock.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class RoleRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());

        [BindRequired]
        [JsonProperty("descricao")]
        public string Description { get; set; }

        [BindRequired]
        [JsonProperty("ativo")]
        public bool Active { get; set; }

        public static implicit operator Role(RoleRequest prop)
        {
            return prop is null ? null : new Role()
            {
                Id = prop.Id,
                Description = prop.Description,
                Active = prop.Active
            };
        }
    }
}
