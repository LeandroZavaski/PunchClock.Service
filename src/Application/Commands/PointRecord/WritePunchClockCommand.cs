using DelMazo.PointRecord.Service.Domain.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class WritePunchClockCommand : IRequest<bool>
    {
        public PunchClock PunchClock { get; set; }

        public WritePunchClockCommand(PunchClock punchClock)
        {
            PunchClock = punchClock;
        }
    }
}
