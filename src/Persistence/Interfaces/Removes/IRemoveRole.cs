using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Removes
{
    public interface IRemoveRole
    {
        Task<RoleResponse> RemoveRoleByIdAsync(string id);
    }
}
