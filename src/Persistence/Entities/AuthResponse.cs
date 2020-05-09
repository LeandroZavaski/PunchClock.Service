using DelMazo.PointRecord.Service.Domain.Entities;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class AuthResponse
    {
        public string Document { get; set; }
        public string Token { get; set; }

        public static implicit operator AuthResponse(Auth prop)
        {
            return prop is null ? null : new AuthResponse()
            {
                Document = prop.Document,
                Token = prop.Token
            };
        }
    }
}
