using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using System;

namespace PunchClock.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class VacationRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());

        [JsonProperty("matricula")]
        public string Registration { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("documento")]
        public Document Document { get; set; }

        [JsonProperty("inicioFerias")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("terminoFerias")]
        public DateTime? EndDate { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public bool Active { get; set; } = true;

        public static implicit operator Vacation(VacationRequest prop)
        {
            return prop is null ? null : new Vacation()
            {
                Id = prop.Id,
                Registration = prop.Registration,
                Name = prop.Name,
                Document = prop.Document,
                StartDate = prop.StartDate,
                EndDate = prop.EndDate,
                DaysNumber = GetDaysNumber(prop.StartDate, prop.EndDate),
                Active = prop.Active
            };
        }

        public static string GetDaysNumber(DateTime? initialDate, DateTime? finalDate)
        {
            var days = 0;
            var daysCount = 0;
            days = initialDate?.Subtract((DateTime)finalDate).Days ?? 0;

            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                initialDate = initialDate?.AddDays(1);

                if (initialDate?.DayOfWeek != DayOfWeek.Sunday &&
                    initialDate?.DayOfWeek != DayOfWeek.Saturday)
                    daysCount++;
            }
            return daysCount.ToString();
        }
    }
}
