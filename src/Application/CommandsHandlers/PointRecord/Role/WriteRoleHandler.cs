using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.Role;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Role
{
    public class WriteRoleHandler : IRequestHandler<WriteRoleCommand, RoleResponse>
    {
        private readonly IWriteRole _writeRepository;

        public WriteRoleHandler(IWriteRole writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RoleResponse> Handle(WriteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WriteRoleAsync(request.Role);
        }
    }
}
