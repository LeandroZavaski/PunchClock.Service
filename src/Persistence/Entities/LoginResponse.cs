using DelMazo.PointRecord.Service.Domain.Entities;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }

        public static implicit operator LoginResponse(Login prop)
        {
            return prop is null ? null : new LoginResponse()
            {
                Id = prop.Id,
                Document = prop.Document,
                Password = prop.Password
            };
        }
    }
}
