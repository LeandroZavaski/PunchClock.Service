using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public partial class Report
    {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeShiftId { get; set; }
        public int EmployeeLoginId { get; set; }
        public int EmployeeVacationId { get; set; }
        public int EmployeeAddressId { get; set; }
        public int EmployeeCompanyId { get; set; }
        public int EmployeeCompanyAddressId { get; set; }
        public int EmployeeCompanyId1 { get; set; }
        public int EmployeeCompanyAddressId1 { get; set; }
        public int EmployeeVacationId1 { get; set; }
    }
}
