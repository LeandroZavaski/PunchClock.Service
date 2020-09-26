using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Vacation
{
    public class RemoveVacationByIdCommand : IRequest<VacationResponse>
    {
        public string Id { get; set; }

        public RemoveVacationByIdCommand(string id)
        {
            Id = id;
        }
    }
}
