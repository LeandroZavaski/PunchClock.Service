using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class RemoveUserByIdCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public RemoveUserByIdCommand(string id)
        {
            Id = id;
        }
    }
}
