using DelMazo.PointRecord.Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class LoginRequest
    {
        public string Document { get; set; }
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
