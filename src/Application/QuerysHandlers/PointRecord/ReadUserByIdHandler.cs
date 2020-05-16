using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadUserByIdHandler : IRequestHandler<ReadUserByIdQuery, UserResponse>
    {
        private readonly IReader _readRepository;

        public ReadUserByIdHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<UserResponse> Handle(ReadUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetById(request.Id);
            return response;
        }
    }
}
