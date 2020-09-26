using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadUsersHandler : IRequestHandler<ReadUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IReadUser _readRepository;

        public ReadUsersHandler(IReadUser readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(ReadUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetUsersAsync();
            return response;
        }
    }
}
