using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord
{
    public class WriteAuthResetHandler : IRequestHandler<WriteAuthResetCommand, AuthResponse>
    {
        private readonly IWrite _writeRepository;

        public WriteAuthResetHandler(IWrite writeRepository)
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
