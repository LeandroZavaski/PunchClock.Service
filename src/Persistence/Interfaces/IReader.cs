using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IReader
    {
        Task<LoginResponse> GetUserLogin(Login login);
    }
}
