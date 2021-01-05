using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;
using PlainClasses.Application.EduBlocks.Queries.GetEduBlocks;

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
        
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EduBlockViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEduBlocks()
        {
            var persons = await _mediator.Send(new GetEduBlocksQuery());

            return Ok(persons);
        }
        
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnEduBlockViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateEduBlock([FromBody]CreateEduBlockRequest request) 
        {
            var eduBlock = await _mediator.Send(new CreateEduBlockCommand(request.EduBlockSubjectId, 
                request.StartEduBlock, request.EndEduBlock, request.Remarks, request.Place, request.PlatoonIds));

            return Created(string.Empty, eduBlock);
        }      
    }
}