using DelMazo.PointRecord.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IRemove
    {
        Task<UserResponse> RemoveUserByIdAsync(string id);

        Task<RoleResponse> RemoveRoleByIdAsync(string id);
    }
}
