using DelMazo.PointRecord.Service.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Persistence.Interfaces
{
    public interface IRemove
    {
        Task<UserResponse> RemoveUserByIdAsync(string id);
    }
}
