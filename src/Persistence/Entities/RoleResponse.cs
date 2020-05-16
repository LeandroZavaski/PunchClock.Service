using DelMazo.PointRecord.Service.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class RoleResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Description { get; set; }

        [JsonProperty("ativo")]
        public byte Active { get; set; }

        public static implicit operator RoleResponse(Role prop)
        {
            return prop is null ? null : new RoleResponse()
            {
                Id = prop.Id,
                Description = prop.Description,
                Active = prop.Active
            };
        }
    }
}
