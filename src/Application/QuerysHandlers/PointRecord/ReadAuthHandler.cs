using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadAuthHandler : IRequestHandler<ReadAuthQuery, AuthResponse>
    {
        private readonly IReadAuth _readRepository;

        public ReadAuthHandler(IReadAuth readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<AuthResponse> Handle(ReadAuthQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAuthLoginAsync(request.Login);
        }
    }
}
