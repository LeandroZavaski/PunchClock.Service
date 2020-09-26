using MediatR;

namespace PunchClock.Service.Application.Commands.PointRecord.PunchClock
{
    public class WritePunchClockCommand : IRequest<bool>
    {
        public Domain.Entities.PunchClock PunchClock { get; set; }

        public WritePunchClockCommand(Domain.Entities.PunchClock punchClock)
        {
            PunchClock = punchClock;
        }
    }
}
