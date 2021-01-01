using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlainClasses.Api.Controllers
{
    [Route("api/eduBlocks")]
    [ApiController]
    public class EduBlockController : Controller
    {
        private readonly IMediator _mediator;

        public EduBlockController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}