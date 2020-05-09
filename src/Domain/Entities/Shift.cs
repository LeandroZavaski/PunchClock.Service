using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public partial class Shift
    {
        public int Id { get; set; }
        public byte Type { get; set; }
        public string Description { get; set; }
    }
}
