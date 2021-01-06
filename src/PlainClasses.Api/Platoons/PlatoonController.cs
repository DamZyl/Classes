using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.Platoons.Commands.CreatePlatoon;
using PlainClasses.Application.Platoons.Commands.DeletePlatoon;
using PlainClasses.Application.Platoons.Queries.GetPlatoon;
using PlainClasses.Application.Platoons.Queries.GetPlatoons;

namespace PlainClasses.Api.Platoons
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
        
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlatoonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlatoons()
        {
            var platoons = await _mediator.Send(new GetPlatoonsQuery());

            return Ok(platoons);
        }
        
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(PlatoonDetailViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPlatoon(Guid id)
        {
            var platoon = await _mediator.Send(new GetPlatoonQuery { Id = id });

            return Ok(platoon);
        }
        
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnPlatoonViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePlatoon([FromBody]CreatePlatoonRequest request) 
        {
            var platoon = await _mediator.Send(new CreatePlatoonCommand(request.Name, request.Acronym, request.Commander));

            return Created(string.Empty, platoon);
        }
        
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeletePlatoon(Guid id)
        {
            await _mediator.Send(new DeletePlatoonCommand { PlatoonId = id});

            return NoContent();
        }
    }
}