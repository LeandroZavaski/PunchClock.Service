using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public partial class Vacation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string DayNumber { get; set; }
    }
}
