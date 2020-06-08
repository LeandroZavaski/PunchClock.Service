using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadAuthHandler : IRequestHandler<ReadAuthQuery, AuthResponse>
    {
        private readonly IReader _readRepository;

        public ReadAuthHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<AuthResponse> Handle(ReadAuthQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAuthLoginAsync(request.Login);
        }
    }
}
