using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DelMazo.PointRecord.Service.Web.Controllers.v1
{
    [Route("/v1/[controller]"), Authorize]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}