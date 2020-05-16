using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using DelMazo.PointRecord.Service.PersistenceDb.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Services
{
    public class Write : IWrite
    {
        private readonly ILogger<Write> _logger;
        private readonly DataContext _context;

        public Write(ILogger<Write> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> WritePunchClock(PunchClock punchClock)
        {
            _logger.LogInformation("Iniciando o processo de inserção do regsitro do ponto, Documento: {0}", punchClock.Id);

            var punche = new PunchClock();
            var todayDate = DateTime.Now.Date.ToString("yyyy-MM-dd");

            //try
            //{
            //    var verifyExist = _context.PunchClock
            //        .Where(w => w.Id.Equals(punchClock.Id) && w.Document.Equals(punchClock.Document))
            //        .Select(a => a.StartWork).Where(w => w.Value.Date.ToString("yyyy-MM-dd").Equals(todayDate)).Take(1) == null;

            //    if (verifyExist)
            //    {
            //        punche = new PunchClock
            //        {
            //            Document = punchClock.Document,
            //            StartWork = DateTime.Now
            //        };
            //    }
            //    else
            //    {
            //        var veryfyRegister = _context.PunchClock.OrderByDescending(o => o.Id.Equals(punchClock.Id) && o.StartWork.Equals(DateTime.Now.ToString("yyyy-MM-dd"))).FirstOrDefault();

            //        if (veryfyRegister == null)
            //        {
            //            punche = new PunchClock
            //            {
            //                Document = punchClock.Document,
            //                StartWork = DateTime.Now
            //            };
            //        }
            //        else
            //        {
            //            punche = new PunchClock
            //            {
            //                Document = punchClock.Document,
            //                FinishWork = DateTime.Now
            //            };
            //        }
            //    }

            //    _context.PunchClock.Add(punche);
            //    await _context.SaveChangesAsync();

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogInformation("Não foi possivel inserir o registro no banco: {0}", ex.Message);
            //    return false;
            //}

            return true;
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
