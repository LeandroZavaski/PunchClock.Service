using MediatR;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadUserByDocumentHandler : IRequestHandler<ReadUserByDocumentQuery, UserResponse>
    {
        private readonly IReadUser _readRepository;

        public ReadUserByDocumentHandler(IReadUser readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<UserResponse> Handle(ReadUserByDocumentQuery request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetUserByDocumentAsync(request.Document);
            return response;
        }
    }
}
