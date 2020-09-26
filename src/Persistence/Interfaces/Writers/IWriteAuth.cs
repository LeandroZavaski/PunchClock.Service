using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Writers
{
    public interface IWriteAuth
    {
        Task<AuthResponse> WriteAuthReset(Auth reset);
    }
}
