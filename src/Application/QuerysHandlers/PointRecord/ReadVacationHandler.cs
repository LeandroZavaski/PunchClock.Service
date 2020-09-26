using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadVacationHandler : IRequestHandler<ReadVacationQuery, IEnumerable<VacationResponse>>
    {
        private readonly IReadVacation _readRepository;

        public ReadVacationHandler(IReadVacation readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<VacationResponse>> Handle(ReadVacationQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetVacationsAsync();
        }
    }
}
