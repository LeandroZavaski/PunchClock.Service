using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Removes
{
    public interface IRemoveVacation
    {
        Task<VacationResponse> RemoveVacationByIdAsync(string id);
    }
}
