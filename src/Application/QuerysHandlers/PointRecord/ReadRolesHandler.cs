using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadRolesHandler : IRequestHandler<ReadRolesQuery, IEnumerable<RoleResponse>>
    {
        private readonly IReadRole _readRepository;

        public ReadRolesHandler(IReadRole readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<RoleResponse>> Handle(ReadRolesQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetRolesAsync();
        }
    }
}
