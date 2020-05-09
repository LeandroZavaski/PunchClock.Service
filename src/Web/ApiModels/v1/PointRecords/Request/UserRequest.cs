using DelMazo.PointRecord.Service.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class UserRequest
    {
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

        public static implicit operator User(UserRequest prop)
        {
            return prop is null ? null : new User()
            {
                Id = Convert.ToString(Guid.NewGuid()),
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
                Role = new Role
                {
                    Id = prop.RoleRequest.Id,
                    Description = prop.RoleRequest.Description,
                    Active = prop.RoleRequest.Active
                },
                Auth = new Auth
                {
                    Id = Convert.ToString(Guid.NewGuid()),
                    Document = prop.DocumentCpf,
                    Password = prop.DocumentCpf
                }
            };
        }
    }
}
