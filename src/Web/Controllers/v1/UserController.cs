using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.Controllers.v1
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

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new ReadUsersQuery());

            if (!response)
                return BadRequest();

            return Ok();
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new ReadUserByIdQuery(id));

            if (!response)
                return BadRequest();

            return Ok();
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserRequest user)
        {
            var response = await _mediator.Send(new WriteUserCommand(user));

            if (!response)
                return BadRequest();

            return Ok();
        }


        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(string id)
        {
            var response = await _mediator.Send(new WriteUserUpdateByIdCommand(id));

            if (!response)
                return BadRequest();

            return Ok();
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpPut]
        [Route("{id}/user")]
        public async Task<ActionResult> Put(string id, [FromBody]UserRequest user)
        {
            var response = await _mediator.Send(new WriteUserUpdateCommand(user, id));

            if (!response)
                return BadRequest();

            return Ok();
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new RemoveUserByIdCommand(id));

            if (!response)
                return BadRequest();

            return Ok();
        }

        [ProducesResponseType(200)]     // Ok
        [ProducesResponseType(400)]     // BadRequest
        [HttpDelete]
        [Route("{id}/user")]
        // POST: User/Delete/5
        public async Task<ActionResult> Delete(string id, [FromBody]UserRequest user)
        {
            var response = await _mediator.Send(new RemoveUserCommand(user, id));

            if (!response)
                return BadRequest();

            return Ok();
        }
    }
}