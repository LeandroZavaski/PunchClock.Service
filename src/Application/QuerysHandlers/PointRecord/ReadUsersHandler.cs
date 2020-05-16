﻿using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
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
    public class ReadUsersHandler : IRequestHandler<ReadUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IReader _readRepository;

        public ReadUsersHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(ReadUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetUserAsync();
            return response;
        }
    }
}