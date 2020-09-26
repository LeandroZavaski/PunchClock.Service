using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Vacation
{
    public class WriteVacationUpdateCommand : IRequest<VacationResponse>
    {
        public string Id { get; set; }
        public Domain.Entities.Vacation Vacation { get; set; }

        public WriteVacationUpdateCommand(Domain.Entities.Vacation vacation, string id)
        {
            Id = id;
            Vacation = vacation;
        }
    }
}
