using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserHandler : IRequestHandler<WriteUserCommand, UserResponse>
    {
        private readonly IWrite _writeRepository;

        public WriteUserHandler(IWrite writeRepository)
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
