using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadUserByIdHandler : IRequestHandler<ReadUserByIdQuery, UserResponse>
    {
        private readonly IReadUser _readRepository;

        public ReadUserByIdHandler(IReadUser readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<UserResponse> Handle(ReadUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetUserByIdAsync(request.Id);
            return response;
        }
    }
}
