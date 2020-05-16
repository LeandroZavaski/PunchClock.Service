using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserUpdateHandler : IRequestHandler<WriteUserUpdateCommand, UserResponse>
    {
        private readonly IWrite _writeRepository;

        public WriteUserUpdateHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UserResponse> Handle(WriteUserUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _writeRepository.WriteUserUpdateAsync(request.User, request.Id);
            return response;
        }
    }
}
