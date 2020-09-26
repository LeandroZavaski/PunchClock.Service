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
    public class RemoveRole : IRemoveRole
    {
        private readonly ILogger<RemoveRole> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public RemoveRole(ILogger<RemoveRole> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<RoleResponse> RemoveRoleByIdAsync(string id)
        {
            _logger.LogInformation("Start remove role by id from db");

            try
            {
                await _context.Remove<Role>(id, ColllectionsEnum.Roles.ToString());

                var response = await _context.Remove<Role>(id, ColllectionsEnum.Roles.ToString());
                var json = JsonConvert.SerializeObject(response);

                return JsonConvert.DeserializeObject<RoleResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed remove role by id from db", ex.Message);
                return null;
            }
        }
    }
}
