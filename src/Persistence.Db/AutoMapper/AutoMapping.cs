using AutoMapper;
using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Login, Task<LoginResponse>>();
            CreateMap<Task<LoginResponse> , Login>();
        }
    }
}
