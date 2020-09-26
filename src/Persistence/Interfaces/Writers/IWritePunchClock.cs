using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Writers
{
    public interface IWritePunchClock
    {
        Task<bool> WritePunchClockAsync(Domain.Entities.PunchClock punchClock);
    }
}
