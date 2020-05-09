﻿using DelMazo.PointRecord.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class WriteUserCommand : IRequest<bool>
    {
        public User User { get; set; }

        public WriteUserCommand(User user)
        {
            User = user;
        }
    }
}
