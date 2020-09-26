using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Readers
{
    public class ReadRole : IReadRole
    {
        private readonly ILogger<ReadRole> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public ReadRole(ILogger<ReadRole> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<RoleResponse>> GetRolesAsync()
        {
            _logger.LogInformation("Start get all roles from db");

            try
            {
                var response = await _context.GetAll<Role>(ColllectionsEnum.Roles.ToString());
                var list = (response.Where(item => (bool)item.Active)).ToList();
                var json = JsonConvert.SerializeObject(list);

                return JsonConvert.DeserializeObject<IEnumerable<RoleResponse>>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get all roles", ex.Message);
                return null;
            }
        }
    }
}
