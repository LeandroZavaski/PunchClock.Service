using DelMazo.PointRecord.Service.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class LoginRequest : BaseUserRequest
    {
        [BindRequired]
        public string Password { get; set; }

        public static implicit operator Login(LoginRequest prop)
        {
            return prop is null ? null : new Login()
            {
                Document = prop.Document,
                Password = prop.Password
            };
        }
    }
}
