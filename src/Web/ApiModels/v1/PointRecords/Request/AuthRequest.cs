using DelMazo.PointRecord.Service.Domain.Entities;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static implicit operator Auth(AuthRequest prop)
        {
            return prop is null ? null : new Auth()
            {
                Username = prop.Username,
                Password = prop.Password
            };
        }
    }
}
