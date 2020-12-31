using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.Persons.Commands.CreatePerson;
using PlainClasses.Application.Persons.Queries.GetPersons;

namespace PlainClasses.Api.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ReturnPersonViewModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePerson([FromBody]CreatePersonRequest request) 
        {
            var person = await _mediator.Send(new CreatePersonCommand(request.PersonalNumber, request.MilitaryRankId, 
                request.PlatoonId, request.FirstName, request.LastName, request.FatherName, request.BirthDate, 
                request.WorkPhoneNumber, request.PersonalPhoneNumber, request.Position));

            return Created(string.Empty, person);
        }      
        
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _mediator.Send(new GetPersonsQuery());

            return Ok(persons);
        }
    }
}