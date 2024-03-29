﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Service.Application.Commands.PointRecord.Auth;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using System.Threading.Tasks;

namespace PunchClock.Service.Web.Controllers.v1
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("/v1/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(AuthResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] AuthRequest login)
        {
            var response = await _mediator.Send(new ReadAuthQuery(login));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(AuthResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpPost]
        [Route("Reset")]
        public async Task<ActionResult> ResetAsync([FromQuery] AuthResetRequest reset)
        {
            var response = await _mediator.Send(new WriteAuthResetCommand(reset));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }
    }
}