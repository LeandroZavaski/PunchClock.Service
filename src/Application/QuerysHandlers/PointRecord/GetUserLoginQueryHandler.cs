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
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, LoginResponse>
    {
        private readonly IReader _readRepository;

        public GetUserLoginQueryHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<LoginResponse> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            return _readRepository.GetUserLogin(request.Login);
        }
    }
}
