using DelMazo.PointRecord.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class RemoveUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public User User { get; set; }

        public RemoveUserCommand(User user, string id)
        {
            Id = id;
            User = user;
        }
    }
}
