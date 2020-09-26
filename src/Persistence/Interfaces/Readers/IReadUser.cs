using PunchClock.Service.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Service.Persistence.Interfaces.Readers
{
    public interface IReadUser
    {
        Task<UserResponse> GetUserByIdAsync(string id);

        Task<IEnumerable<UserResponse>> GetUsersAsync();

        Task<UserResponse> GetUserByDocumentAsync(string document);


    }
}
