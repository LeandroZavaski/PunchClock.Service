using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Vacation
{
    public class WriteVacationCommand : IRequest<VacationResponse>
    {
        public Domain.Entities.Vacation Vacation { get; set; }

        public WriteVacationCommand(Domain.Entities.Vacation vacation)
        {
            Vacation = vacation;
        }
    }
}
