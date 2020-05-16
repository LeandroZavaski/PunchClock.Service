using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IWrite
    {
        Task<bool> WritePunchClock(PunchClock punchClock);

        Task<AuthResponse> WriteAuthReset(Auth reset);

        Task<UserResponse> WriteUserAsync(User user);

        Task<UserResponse> WriteUserUpdateAsync(User user, string id);
        
    }
}
