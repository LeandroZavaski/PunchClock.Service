﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Service.Application.Commands.PointRecord.PunchClock;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using System.Threading.Tasks;

namespace PunchClock.Service.Web.Controllers.v1
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("/v1/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPost]
        [Route("PunchClock")]
        public async Task<ActionResult> Post([FromBody] PunchClockRequest punchClock)
        {
            var response = await _mediator.Send(new WritePunchClockCommand(punchClock));

            if (!response)
                return BadRequest();

            return Ok();
        }
    }
}