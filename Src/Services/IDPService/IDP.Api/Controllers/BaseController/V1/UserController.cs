using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDP.Application.Command.User;
using Asp.Versioning;

namespace IDP.Api.Controllers.BaseController.V1
{
    [ApiController]
    [ApiVersion(2)]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/Users")]
    
    public class UserController : IBaseController
    {
        public readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //افزودن کاربر جدید
        [MapToApiVersion(1)]
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] UserCommand userCommand)
        {
            var res = await _mediator.Send(userCommand);
            return Ok(res);
        }
    }
}
