using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Api.EduBlocks.Requests;
using PlainClasses.Application.EduBlocks.Commands.AddPlatoon;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;
using PlainClasses.Application.EduBlocks.Commands.DeleteEduBlock;
using PlainClasses.Application.EduBlocks.Commands.UpdateEduBlock;
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
        
        [Route("{id}/platoon/{platoonId}")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnEduBlockViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddPlatoonToEduBlock(Guid id, Guid platoonId) 
        {
            var eduBlock = await _mediator.Send(new AddPlatoonCommand(id, platoonId));

            return Created(string.Empty, eduBlock);
        }
        
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateEduBlock(Guid id, [FromBody]UpdateEduBlockRequest request)
        {
            await _mediator.Send(new UpdateEduBlockCommand(id, request.Remarks, request.Place, 
                request.StartEduBlock, request.EndEduBlock));

            return NoContent();
        }
        
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteEduBlock(Guid id)
        {
            await _mediator.Send(new DeleteEduBlockCommand(id));

            return NoContent();
        }
    }
}