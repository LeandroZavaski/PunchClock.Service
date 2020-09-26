using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Writers
{
    public interface IWriteRole
    {
        Task<RoleResponse> WriteRoleAsync(Role role);

        Task<RoleResponse> WriteRoleUpdateAsync(Role role, string id);
    }
}
