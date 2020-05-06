using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/v1/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(LoginResponse), 200)]     // Ok
        [ProducesResponseType(400)]                            // BadRequest
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] LoginRequest user)
        {
            var response = await _mediator.Send(new ReadUserLoginQuery(user));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }
    }
}