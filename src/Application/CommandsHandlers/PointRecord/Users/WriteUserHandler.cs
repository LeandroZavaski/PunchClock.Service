using MediatR;
using PunchClock.Service.Application.Commands.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserHandler : IRequestHandler<WriteUserCommand, UserResponse>
    {
        private readonly IWriteUser _writeRepository;

        public WriteUserHandler(IWriteUser writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UserResponse> Handle(WriteUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _writeRepository.WriteUserAsync(request.User);
            return response;
        }
    }
}
