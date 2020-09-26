using MediatR;
using PunchClock.Service.Application.Commands.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Removes;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class RemoveUserByIdHandler : IRequestHandler<RemoveUserByIdCommand, UserResponse>
    {
        private readonly IRemoveUser _removeRepository;

        public RemoveUserByIdHandler(IRemoveUser removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<UserResponse> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
        {
            return await _removeRepository.RemoveUserByIdAsync(request.Id);
        }
    }
}
