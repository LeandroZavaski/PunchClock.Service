using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.PunchClock;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.PunchClock
{
    public class WritePunchClockHandler : IRequestHandler<WritePunchClockCommand, bool>
    {
        private readonly IWritePunchClock _writeRepository;
        public WritePunchClockHandler(IWritePunchClock writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(WritePunchClockCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WritePunchClockAsync(request.PunchClock);
        }
    }
}
