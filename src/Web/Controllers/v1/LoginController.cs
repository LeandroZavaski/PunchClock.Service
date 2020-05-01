using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Web.ApiModels.v1.PointRecords.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DelMazo.PointRecord.Service.Web.Controllers.v1
{
    [Route("/v1/[controller]")]
    //[Authorize]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(LoginResponse), 200)]     // Ok
        [ProducesResponseType(400)]                               // BadRequest
        [HttpGet]
        public ActionResult Get([FromQuery] LoginRequest user)
        {
            var users = _mediator.Send(new GetUserLoginQuery(user));

            if (user is null)
                return BadRequest();

            return Ok();
        }
    }
}