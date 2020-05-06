using System.ComponentModel.DataAnnotations.Schema;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public class Login : BaseUser
    {
        public string Password { get; set; }
    }
}
