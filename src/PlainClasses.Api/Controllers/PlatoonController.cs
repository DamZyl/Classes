using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlainClasses.Api.Controllers
{
    [Route("api/platoons")]
    [ApiController]
    public class PlatoonController : Controller
    {
        private readonly IMediator _mediator;

        public PlatoonController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}