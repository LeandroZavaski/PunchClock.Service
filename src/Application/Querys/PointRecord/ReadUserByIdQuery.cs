using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
{
    public class ReadUserByIdQuery : IRequest<bool>
    {
        public string Id { get; set; }

        public ReadUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
