using DelMazo.PointRecord.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class WriteUserUpdateByIdCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public WriteUserUpdateByIdCommand(string id)
        {
            Id = id;
        }
    }
}
