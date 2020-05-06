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
    public class ReadUserLoginHandler : IRequestHandler<ReadUserLoginQuery, LoginResponse>
    {
        private readonly IReader _readRepository;

        public ReadUserLoginHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<LoginResponse> Handle(ReadUserLoginQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetUserLogin(request.Login);
        }
    }
}
