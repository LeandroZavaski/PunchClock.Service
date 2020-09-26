using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Service.Application.Commands.PointRecord.Role;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Service.Web.Controllers.v1
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("/v1/[controller]/")]
    [Produces("application/json")]
    //[Authorize]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), 200)]     // Ok
        [ProducesResponseType(400)]                            // BadRequest
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new ReadRolesQuery());

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        //[ProducesResponseType(typeof(RolesResponse), 200)]     // Ok
        //[ProducesResponseType(400)]                            // BadRequest
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult> GetById(string id)
        //{
        //    return View();
        //}

        [ProducesResponseType(typeof(RoleResponse), 200)]     // Ok
        [ProducesResponseType(400)]                            // BadRequest
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleRequest role)
        {
            var response = await _mediator.Send(new WriteRoleCommand(role));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(RoleResponse), 200)]     // Ok
        [ProducesResponseType(400)]                            // BadRequest
        [HttpPut]
        [Route("{id}/roles")]
        public async Task<ActionResult> Put(string id, [FromBody] RoleRequest role)
        {
            var response = await _mediator.Send(new WriteRoleUpdateCommand(id, role));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(RoleResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new RemoveRoleByIdCommand(id));

            if (!(response is null))
                return BadRequest();

            return Ok(response);
        }
    }
}