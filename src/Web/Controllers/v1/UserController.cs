using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Service.Application.Commands.PointRecord;
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
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new ReadUsersQuery());

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(UserResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new ReadUserByIdQuery(id));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(UserResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpGet]
        [Route("{document}/document")]
        public async Task<ActionResult> GetByDocument(string document)
        {
            var response = await _mediator.Send(new ReadUserByDocumentQuery(document));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(UserResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRequest user)
        {
            var response = await _mediator.Send(new WriteUserCommand(user));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(UserResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpPut]
        [Route("{id}/user")]
        public async Task<ActionResult> Put(string id, [FromBody] UserRequest user)
        {
            var response = await _mediator.Send(new WriteUserUpdateCommand(user, id));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [ProducesResponseType(typeof(UserResponse), 200)]     // Ok
        [ProducesResponseType(400)]                           // BadRequest
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new RemoveUserByIdCommand(id));

            if (!(response is null))
                return BadRequest();

            return Ok(response);
        }
    }
}