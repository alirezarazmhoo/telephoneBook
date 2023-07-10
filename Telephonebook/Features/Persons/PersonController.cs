using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telephonebook.Models;

namespace Telephonebook.Features.Persons
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IMediator _mediator;
		public PersonController(IMediator mediator) => _mediator = mediator;

		[HttpGet]
		public async Task<IEnumerable<Person>> GetPersons() => await _mediator.Send(new GetPerson.Query());

		[HttpGet("{id}")]
		public async Task<Person> GetPerson(int id) => await _mediator.Send(new GetPersonById.Query { Id = id });
		[HttpPost]
		public async Task<ActionResult> CreatePerson([FromBody] AddNewPerson.Command command)
		{
			var createPersonId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetPerson), new { id = createPersonId }, null);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerson(int id)
		{
			await _mediator.Send(new RemovePerson.Command { Id = id });
			return NoContent();
		}
		[HttpGet("{title},{Mobile}")]
		public async Task<Person> SearchPerson(string title , long Mobile) => await _mediator.Send(new SearchPerson.Query {  mobile = Mobile , title = title});
	}
}
