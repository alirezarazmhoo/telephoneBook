using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telephonebook.Models;
using Telephonebook.Validator;

namespace Telephonebook.Features.Persons
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _Mediator;
		public PersonController(IMediator mediator, IMapper mapper) {
			_Mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<Person>> GetPersons() { 
		var model = await _Mediator.Send(new GetPerson.Query());
		var list = new List<Person>();
			foreach (var item in model)
			{
				list.Add(_mapper.Map<Person>(item));
			}
		return   list ;
		}

		[HttpGet("{id}")]
		public async Task<Person> GetPerson(int id) {
		var item =	await _Mediator.Send(new GetPersonById.Query { Id = id });
		var mapitem = _mapper.Map<Person>(item); 
		return mapitem;
		} 
		[HttpPost]
		public async Task<ActionResult> CreatePerson([FromBody] AddNewPerson.Command command)
		{
			var validator = new RegisterPersonValidator();
			var result = await validator.ValidateAsync(command);
			if (!result.IsValid)
			{
				return BadRequest(result.Errors[0].ErrorMessage);
			}

			var createPersonId = await _Mediator.Send(command);
			return CreatedAtAction(nameof(GetPerson), new { id = createPersonId }, null);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePerson(int id)
		{
			await _Mediator.Send(new RemovePerson.Command { Id = id });
			return NoContent();
		}
		[HttpGet("{title},{Mobile}")]
		public async Task<Person> SearchPerson(string title, long Mobile) {
		var Item = 	await _Mediator.Send(new SearchPerson.Query { Mobile = Mobile, Title = title });
			var mapitem = _mapper.Map<Person>(Item);
			return mapitem;

		}
	}
}
