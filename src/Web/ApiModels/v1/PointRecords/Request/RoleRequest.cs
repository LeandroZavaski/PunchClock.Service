using DelMazo.PointRecord.Service.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class RoleRequest
    {
        public string Id { get; set; }

        [BindRequired]
        [JsonProperty("descricao")]
        public string Description { get; set; }

        [BindRequired]
        [JsonProperty("ativo")]
        public byte Active { get; set; }

        public static implicit operator Role(RoleRequest prop)
        {
            return prop is null ? null : new Role()
            {
                Description = prop.Description,
                Active = prop.Active
            };
        }
    }
}
