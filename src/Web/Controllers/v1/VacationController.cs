using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Service.Application.Commands.PointRecord.Vacation;
using PunchClock.Service.Application.Querys.PointRecord;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Web.ApiModels.v1.PointRecords.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Service.Web.Controllers.v1
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("/v1/[controller]")]
    [Produces("application/json")]
    //[Authorize]

    public class VacationController : Controller
    {
        private readonly IMediator _mediator;

        public VacationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Vacation
        [ProducesResponseType(typeof(IEnumerable<VacationResponse>), 200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new ReadVacationQuery());

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        // POST: Vacation/Create
        [ProducesResponseType(typeof(VacationResponse), 200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VacationRequest vacation)
        {
            var response = await _mediator.Send(new WriteVacationCommand(vacation));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        // POST: Vacation/Edit/5
        [ProducesResponseType(typeof(VacationResponse), 200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPut]
        [Route("{id}/vacation")]
        public async Task<ActionResult> Put(string id, [FromBody] VacationRequest vacation)
        {
            var response = await _mediator.Send(new WriteVacationUpdateCommand(vacation, id));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(VacationResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new RemoveVacationByIdCommand(id));

            if (!(response is null))
                return BadRequest();

            return Ok(response);
        }

    }
}
