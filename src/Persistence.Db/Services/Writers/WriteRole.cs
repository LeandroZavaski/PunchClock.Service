using Microsoft.Extensions.Logging;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Writers
{
    public class WriteRole : IWriteRole
    {
        private readonly ILogger<WriteRole> _logger;
        private readonly DataContext _context;

        public WriteRole(ILogger<WriteRole> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<RoleResponse> WriteRoleAsync(Role role)
        {
            _logger.LogInformation("Start write role");

            try
            {
                var response = await _context.Add(role, role.Id, ColllectionsEnum.Roles.ToString());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible load data roleId: {role.Id}");
                return null;
            }
        }

        public async Task<RoleResponse> WriteRoleUpdateAsync(Role role, string id)
        {
            _logger.LogInformation("Start update role");

            try
            {
                //Update user
                role.Id = id;
                var response = await _context.Update(role, id, ColllectionsEnum.Roles.ToString());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible update data roleId: {id}");
                return null;
            }
        }
    }
}
