using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.Auth;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Auth
{
    public class WriteAuthResetHandler : IRequestHandler<WriteAuthResetCommand, AuthResponse>
    {
        private readonly IWriteAuth _writeRepository;

        public WriteAuthResetHandler(IWriteAuth writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<AuthResponse> Handle(WriteAuthResetCommand request, CancellationToken cancellationToken)
        {
            var response = await _writeRepository.WriteAuthReset(request.Auth);
            return response;
        }
    }
}
