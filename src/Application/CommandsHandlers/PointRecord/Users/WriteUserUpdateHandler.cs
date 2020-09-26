using MediatR;
using PunchClock.Service.Application.Commands.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserUpdateHandler : IRequestHandler<WriteUserUpdateCommand, UserResponse>
    {
        private readonly IWriteUser _writeRepository;

        public WriteUserUpdateHandler(IWriteUser writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UserResponse> Handle(WriteUserUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WriteUserUpdateAsync(request.User, request.Id);
        }
    }
}
