using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.Vacation;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Vacation
{
    public class WriteVacationHandler : IRequestHandler<WriteVacationCommand, VacationResponse>
    {
        private readonly IWriteVacation _writeRepository;

        public WriteVacationHandler(IWriteVacation writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<VacationResponse> Handle(WriteVacationCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WriteVacationAsync(request.Vacation);
        }
    }
}
