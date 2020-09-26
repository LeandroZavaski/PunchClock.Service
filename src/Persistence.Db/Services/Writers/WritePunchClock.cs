using Microsoft.Extensions.Logging;
using PunchClock.Service.Persistence.Interfaces.Writers;
using PunchClock.Service.PersistenceDb.Context;
using System;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Writers
{
    public class WritePunchClock : IWritePunchClock
    {
        private readonly ILogger<WritePunchClock> _logger;
        private readonly DataContext _context;

        public WritePunchClock(ILogger<WritePunchClock> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> WritePunchClockAsync(Domain.Entities.PunchClock punchClock)
        {
            _logger.LogInformation("Iniciando o processo de inserção do regsitro do ponto, Documento: {0}", punchClock.Id);

            var punche = new Domain.Entities.PunchClock();
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
    }
}
