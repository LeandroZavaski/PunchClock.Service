using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Readers
{
    public interface IReadAuth
    {
        Task<AuthResponse> GetAuthLoginAsync(Auth login);
    }
}
