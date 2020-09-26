using Newtonsoft.Json;
using PunchClock.Service.Application.Helpers;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Domain.Enums;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PunchClock.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class UserRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("dataNascimento")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("telefone")]
        public string Phone { get; set; }

        [JsonProperty("sexo")]
        public byte Gender { get; set; }

        [JsonProperty("cpf")]
        public List<Document> Documents { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("endereco")]
        public Address Address { get; set; }

        [JsonProperty("dataContratacao")]
        public DateTime StartDate { get; set; }

        [JsonProperty("dataDemissao")]
        public DateTime? FinishDate { get; set; }

        [JsonProperty("turno")]
        public string Shift { get; set; }

        [JsonProperty("ativo")]
        public bool Active { get; set; }

        [JsonProperty("funcao")]
        public RoleUserRequest RoleRequest { get; set; }

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
                Documents = prop.Documents,
                Email = prop.Email,
                Address = prop.Address,
                StartDate = prop.StartDate,
                FinishDate = prop?.FinishDate,
                Active = prop.Active,
                Role = new Role
                {
                    Id = prop.RoleRequest.Id,
                    Description = prop.RoleRequest.Description,
                    Active = prop.RoleRequest.Active
                },
                Auth = new Auth
                {
                    Id = prop.Id,
                    Document = GetDocumentNumber(prop.Documents),
                    Password = PointRecordHashPass.Encrypt(GetDocumentNumber(prop.Documents)),
                    FirstAccess = true
                },
                Collections = new List<Collections>
                {
                    new Collections{ Description = ColllectionsEnum.Users.ToString() },
                    new Collections{ Description = ColllectionsEnum.Auths.ToString() },
                }
            };
        }

        private static string GetDocumentNumber(List<Document> documents)
        {
            return documents.FirstOrDefault(w => w.Type.ToLower().Equals(DocumentType.Cpf)).Number;
        }
    }

    public class RoleUserRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("descricao")]
        public string Description { get; set; }

        [JsonProperty("ativo")]
        public bool Active { get; set; }

        public static implicit operator Role(RoleUserRequest prop)
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
