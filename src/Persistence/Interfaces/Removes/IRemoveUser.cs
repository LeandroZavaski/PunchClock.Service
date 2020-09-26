using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Removes
{
    public interface IRemoveUser
    {
        Task<UserResponse> RemoveUserByIdAsync(string id);
    }
}
