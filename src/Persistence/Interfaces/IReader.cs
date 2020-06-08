using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IReader
    {
        Task<AuthResponse> GetAuthLoginAsync(Auth login);
        
        Task<UserResponse> GetUserByIdAsync(string id);

        Task<IEnumerable<UserResponse>> GetUserAsync();

        Task<IEnumerable<RoleResponse>> GetRolesAsync();
    }
}
