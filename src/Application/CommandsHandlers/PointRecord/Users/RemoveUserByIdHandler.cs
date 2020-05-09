using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class RemoveUserByIdHandler : IRequestHandler<RemoveUserByIdCommand, bool>
    {
        private readonly IRemove _removeRepository;

        public RemoveUserByIdHandler(IRemove removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<bool> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
