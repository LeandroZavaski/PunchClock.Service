using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord.Role
{
    public class RemoveRoleByIdCommand : IRequest<RoleResponse>
    {
        public string Id { get; set; }

        public RemoveRoleByIdCommand(string id)
        {
            Id = id;
        }
    }
}
