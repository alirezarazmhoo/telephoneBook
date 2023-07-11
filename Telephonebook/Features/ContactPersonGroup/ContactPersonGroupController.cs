using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telephonebook.Features.Persons;
using Telephonebook.Models;
using Telephonebook.Validator;
using Telephonebook.ViewModel;

namespace Telephonebook.Features.ContactPersonGroup
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactPersonGroupController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _Mediator;
		public ContactPersonGroupController(IMediator mediator, IMapper mapper)
		{
			_Mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IEnumerable<ContactGroup>> GetContactGroup()
		{
			var model = await _Mediator.Send(new GetAllContactPersonGroup.Query());
			var list = new List<ContactGroup>();
			foreach (var item in model)
			{
				list.Add(_mapper.Map<ContactGroup>(item));
			}
			return list;
		}
		[HttpGet("api/GetContactGroupById/{id}")]
		public async Task<ContactGroup> GetContactGroupById(int id)
		{
			var item = await _Mediator.Send(new GetContactGroupById.Query { Id = id });
			var mapitem = _mapper.Map<ContactGroup>(item);
			return mapitem;
		}
		[HttpGet("api/GetContactGroupDetailById/{groupId}")]
		public async Task<PersonInContactGroupViewModel> GetContactGroupDetailById(int groupId)
		{
			var ViewModel = new PersonInContactGroupViewModel();
			var groupitem = await _Mediator.Send(new GetContactGroupById.Query { Id = groupId });
			var item = await _Mediator.Send(new GetPersonToGroupDetail.Query {  GroupId = groupId });
			var mapitem = _mapper.Map<ContactGroup>(groupitem);
			var list = new List<PersonViewModel>();
			foreach (var data in item.Select(s=>s.Person))
			{
				list.Add(_mapper.Map<PersonViewModel>(data));
			}
			ViewModel.ContactGroup = mapitem;
			ViewModel.PersonViewModel = list;
			return ViewModel;
		}

		[HttpPost]
		[Route("CreateContactGroup")]
		public async Task<ActionResult> CreateContactGroup([FromBody] AddContactGroup.ContactGroupCommand command)
		{
			var validator = new RegisterContactGroup();
			var result = await validator.ValidateAsync(command);
			if (!result.IsValid)
			{
				return BadRequest(result.Errors[0].ErrorMessage);
			}

			var createContactGroupId = await _Mediator.Send(command);
			return CreatedAtAction(nameof(GetContactGroup), new { id = createContactGroupId }, null);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteGetContactGroup(int id)
		{
			await _Mediator.Send(new RemoveContactGroup.Command { Id = id });
			return NoContent();
		}
		[HttpPut]
		public async Task<ActionResult> EditContactGroup([FromBody] EditContactGroup.EditContactGroupCommand command)
		{
			var EditContactGroupId = await _Mediator.Send(command);
			return CreatedAtAction(nameof(GetContactGroup), new { id = EditContactGroupId }, null);
		}


	}
}
