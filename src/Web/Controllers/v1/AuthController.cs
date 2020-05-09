using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Web.Controllers.v1
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
        [ProducesResponseType(400)]                            // BadRequest
        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] AuthRequest login)
        {
            var response = await _mediator.Send(new ReadAuthQuery(login));

            if (response is null)
                return BadRequest();

            return Ok(response);
        }
    }
}