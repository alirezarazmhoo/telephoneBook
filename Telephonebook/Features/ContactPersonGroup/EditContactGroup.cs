using MediatR;
using static Telephonebook.Features.ContactPersonGroup.AddContactGroup;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;
using Telephonebook.Interfaces;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class EditContactGroup
	{
		public class EditContactGroupCommand : IRequest<int>
		{
			public int GroupId { get; set; }
			public List<int>? PersonIds { get; set;}
		}
		public class CommandHandler : IRequestHandler<EditContactGroupCommand, int>
		{
			public readonly IEditContactGroupRepository _Repository;
			public CommandHandler(IEditContactGroupRepository repository)
			{
				_Repository = repository;
			}
			public async Task<int> Handle(EditContactGroupCommand request, CancellationToken cancellationToken)
			{
			if(request.PersonIds !=null)
			await _Repository.AddAsync(request.GroupId , request.PersonIds);
			return request.GroupId;
			}
		}
	}
}
