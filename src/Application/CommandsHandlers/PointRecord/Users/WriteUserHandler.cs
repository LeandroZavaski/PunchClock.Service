using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserHandler : IRequestHandler<WriteUserCommand, bool>
    {
        private readonly IWrite _writeRepository;

        public WriteUserHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(WriteUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _writeRepository.WriteUserAsync(request.User);
            return response;
        }
    }
}
