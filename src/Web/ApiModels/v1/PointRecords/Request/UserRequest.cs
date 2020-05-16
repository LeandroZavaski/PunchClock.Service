using DelMazo.PointRecord.Service.Application.Helpers;
using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.PersistenceDb.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class UserRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());

        [JsonProperty("matricula")]
        public string Registration { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("dataNascimento")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("telefone")]
        public string Phone { get; set; }

        [JsonProperty("sexo")]
        public byte Gender { get; set; }

        [JsonProperty("cpf")]
        public string DocumentCpf { get; set; }

        [JsonProperty("rg")]
        public string DocumentRg { get; set; }

        [JsonProperty("pis")]
        public string DocumentPis { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dataContratacao")]
        public DateTime StartDate { get; set; }

        [JsonProperty("dataDemissao")]
        public DateTime? FinishDate { get; set; }

        [JsonProperty("ativo")]
        public byte Active { get; set; }

        [JsonProperty("funcao")]
        public RoleRequest RoleRequest { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public IEnumerable<Collections> Collections { get; set; }


        public static implicit operator User(UserRequest prop)
        {
            return prop is null ? null : new User()
            {
                Id = prop.Id,
                Name = prop.Name,
                BirthDate = prop.BirthDate,
                Phone = prop.Phone,
                Gender = prop.Gender,
                DocumentCpf = prop.DocumentCpf,
                DocumentRg = prop.DocumentRg,
                DocumentPis = prop.DocumentPis,
                Email = prop.Email,
                StartDate = prop.StartDate,
                FinishDate = prop.FinishDate,
                Active = prop.Active,
                Registration = prop.Registration,
                Role = new Role
                {
                    Id = prop.RoleRequest.Id,
                    Description = prop.RoleRequest.Description,
                    Active = prop.RoleRequest.Active
                },
                Auth = new Auth
                {
                    Id = prop.Id,
                    Document = prop.DocumentCpf,
                    Password = PointRecordHasshPass.Encrypt(prop.DocumentCpf)
                },
                Collections = new List<Collections>
                {
                    new Collections{ Description = ColllectionsEnum.Users.ToString() },
                    new Collections{ Description = ColllectionsEnum.Auths.ToString() },
                }
            };
        }
    }
}
