using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class WriteUserUpdateHandler : IRequestHandler<WriteUserUpdateCommand, bool>
    {
        private readonly IWrite _writeRepository;

        public WriteUserUpdateHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(WriteUserUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
