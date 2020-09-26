using PunchClock.Service.Domain.Entities;
using System;

namespace PunchClock.Service.Persistence.Entities
{
    public class VacationResponse
    {
        public string Id { get; set; }

        public string Registration { get; set; }

        public string Name { get; set; }

        public Document Document { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string DaysNumber { get; set; }

        public bool Active { get; set; }

        public static implicit operator VacationResponse(Vacation prop)
        {
            return prop is null ? null : new VacationResponse()
            {
                Id = prop.Id,
                Registration = prop.Registration,
                Name = prop.Name,
                Document = prop.Document,
                StartDate = prop.StartDate,
                EndDate = prop.EndDate,
                DaysNumber = prop.DaysNumber,
                Active = prop.Active
            };
        }
    }
}
