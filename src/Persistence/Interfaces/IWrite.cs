using DelMazo.PointRecord.Service.Domain.Entities;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IWrite
    {
        Task<bool> WritePunchClock(PunchClock punchClock);
        Task<bool> WriteUserAsync(User user);
    }
}
