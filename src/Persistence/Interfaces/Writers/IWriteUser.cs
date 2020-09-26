using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Writers
{
    public interface IWriteUser
    {
        Task<UserResponse> WriteUserAsync(User user);

        Task<UserResponse> WriteUserUpdateAsync(User user, string id);
    }
}
