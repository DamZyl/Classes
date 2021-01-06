using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.Auths.Commands.Login;

namespace PlainClasses.Api.Auths
{
    [Route("api/auths")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnLoginViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Login([FromBody]LoginRequest request) 
        {
            var token = await _mediator.Send(new LoginCommand(request.PersonalNumber, request.Password));

            return Created(string.Empty, token);
        }
    }
}