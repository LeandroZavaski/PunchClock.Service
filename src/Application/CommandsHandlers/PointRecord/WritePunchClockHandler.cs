using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord
{
    public class WritePunchClockHandler : IRequestHandler<WritePunchClockCommand, bool>
    {
        private readonly IWrite _writeRepository;
        public WritePunchClockHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(WritePunchClockCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WritePunchClock(request.PunchClock);
        }
    }
}
