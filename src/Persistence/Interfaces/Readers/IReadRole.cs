using PunchClock.Service.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Readers
{
    public interface IReadRole
    {
        Task<IEnumerable<RoleResponse>> GetRolesAsync();
    }
}
