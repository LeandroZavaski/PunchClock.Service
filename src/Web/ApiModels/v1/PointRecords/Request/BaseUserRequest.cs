using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request
{
    public class BaseUserRequest
    {
        public int Id { get; set; } = 0;
        [BindRequired]
        public string Document { get; set; }
    }
}
