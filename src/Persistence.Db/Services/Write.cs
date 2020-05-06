using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Services
{
    public class Write : IWrite
    {
        private readonly ILogger<Write> _logger;
        private readonly PointRecordContext _context;

        public Write(ILogger<Write> logger, PointRecordContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> WritePunchClock(PunchClock punchClock)
        {
            _logger.LogInformation("Iniciando o processo de inserção do regsitro do ponto, Documento: {0}", punchClock.Id);

            var punche = new PunchClock();
            var todayDate = DateTime.Now.Date.ToString("yyyy-MM-dd");

            try
            {
                var verifyExist = _context.PunchClock
                    .Where(w => w.Id.Equals(punchClock.Id) && w.Document.Equals(punchClock.Document))
                    .Select(a => a.StartWork).Where(w => w.Value.Date.ToString("yyyy-MM-dd").Equals(todayDate)).Take(1) == null;

                if (verifyExist)
                {
                    punche = new PunchClock
                    {
                        Document = punchClock.Document,
                        StartWork = DateTime.Now
                    };
                }
                else
                {
                    var veryfyRegister = _context.PunchClock.OrderByDescending(o => o.Id.Equals(punchClock.Id) && o.StartWork.Equals(DateTime.Now.ToString("yyyy-MM-dd"))).FirstOrDefault();

                    if (veryfyRegister == null)
                    {
                        punche = new PunchClock
                        {
                            Document = punchClock.Document,
                            StartWork = DateTime.Now
                        };
                    }
                    else
                    {
                        punche = new PunchClock
                        {
                            Document = punchClock.Document,
                            FinishWork = DateTime.Now
                        };
                    }
                }

                _context.PunchClock.Add(punche);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Não foi possivel inserir o registro no banco: {0}", ex.Message);
                return false;
            }
        }
    }
}
