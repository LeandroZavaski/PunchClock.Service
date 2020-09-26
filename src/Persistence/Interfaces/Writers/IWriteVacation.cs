using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Writers
{
    public interface IWriteVacation
    {
        Task<VacationResponse> WriteVacationAsync(Vacation vacation);

        Task<VacationResponse> WriteVacationUpdateAsync(Vacation vacation, string id);
    }
}
