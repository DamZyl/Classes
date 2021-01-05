using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;
using PlainClasses.Application.EduBlocks.Commands.DeleteEduBlock;
using PlainClasses.Application.EduBlocks.Queries.GetEduBlock;
using PlainClasses.Application.EduBlocks.Queries.GetEduBlocks;

namespace PlainClasses.Api.EduBlocks
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
            var eduBlocks = await _mediator.Send(new GetEduBlocksQuery());

            return Ok(eduBlocks);
        }
        
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(EduBlockDetailViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEduBlock(Guid id)
        {
            var eduBlock = await _mediator.Send(new GetEduBlockQuery { Id = id });

            return Ok(eduBlock);
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
        
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteEduBlock(Guid id)
        {
            await _mediator.Send(new DeleteEduBlockCommand { EduBlockId = id});

            return NoContent();
        }
    }
}