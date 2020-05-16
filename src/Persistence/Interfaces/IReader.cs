using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IReader
    {
        Task<AuthResponse> GetAuthLogin(Auth login);
        
        Task<UserResponse> GetById(string id);

        Task<IEnumerable<UserResponse>> GetUserAsync();
    }
}
