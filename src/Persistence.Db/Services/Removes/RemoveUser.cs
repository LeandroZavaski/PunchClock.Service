using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Removes;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Removes
{
    public class RemoveUser : IRemoveUser
    {
        private readonly ILogger<RemoveUser> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public RemoveUser(ILogger<RemoveUser> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> RemoveUserByIdAsync(string id)
        {
            _logger.LogInformation("Start remove user by id from db");

            try
            {
                await _context.Remove<Auth>(id, ColllectionsEnum.Auths.ToString());

                var response = await _context.Remove<User>(id, ColllectionsEnum.Users.ToString());
                var json = JsonConvert.SerializeObject(response);

                return JsonConvert.DeserializeObject<UserResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed remove user by id from db", ex.Message);
                return null;
            }
        }
    }
}
