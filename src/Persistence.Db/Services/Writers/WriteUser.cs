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
    public class WriteUser : IWriteUser
    {
        private readonly ILogger<WriteUser> _logger;
        private readonly DataContext _context;

        public WriteUser(ILogger<WriteUser> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<UserResponse> WriteUserAsync(User user)
        {
            _logger.LogInformation("Start load customer userId: ", user.Id);
            var response = new User();

            try
            {
                foreach (var collection in user.Collections)
                {
                    if (collection.Description.Equals(ColllectionsEnum.Users.ToString()))
                    {
                        //Load user
                        var registration = await _context.GetSequenceValue("user", ColllectionsEnum.Sequence.ToString());
                        user.Registration = registration.ToString();
                        response = await _context.Add(user, user.Id, collection.Description);
                    }
                    else
                    {
                        //Load login Auth
                        await _context.Add(user.Auth, user.Id, collection.Description);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible load data userId: {user.Id}");
                return null;
            }

        }

        public async Task<UserResponse> WriteUserUpdateAsync(User user, string id)
        {
            _logger.LogInformation("Start update customer userId: ", id);

            try
            {
                //Update user
                user.Id = id;
                var response = await _context.Update(user, id, ColllectionsEnum.Users.ToString());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible update data userId: {id}");
                return null;
            }
        }
    }
}
