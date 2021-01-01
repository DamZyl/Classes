using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlainClasses.Api.Controllers
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
    }
}